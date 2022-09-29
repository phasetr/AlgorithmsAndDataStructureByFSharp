// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_14_C/review/4818227/regonn/Rust
use std::collections::HashSet;
use std::io::*;
use std::str::FromStr;

fn read<T: FromStr>() -> T {
  let stdin = stdin();
  let stdin = stdin.lock();
  let token: String = stdin
    .bytes()
    .map(|c| c.expect("failed to read char") as char)
    .skip_while(|c| c.is_whitespace())
    .take_while(|c| !c.is_whitespace())
    .collect();
  token.parse().ok().expect("failed to parse token")
}

fn match_rolling_hash_2d(
  s: &Vec<Vec<char>>,
  p: &Vec<Vec<char>>,
  MOD: isize,
  base: isize,
) -> HashSet<(usize, usize)> {
  let H = s.len();
  let W = s[0].len();
  let R = p.len();
  let C = p[0].len();
  if H < R || W < C {
    return HashSet::new();
  }

  let mut Ph = ModInt::new(0, MOD);
  let base_v = ModInt::pow_mod(base, C as isize, MOD);
  for row in p {
    for &p in row {
      Ph *= base;
      Ph += p as isize;
    }
  }
  let Ph = Ph;

  let mut ret = HashSet::new();

  let mut h_h = Vec::new();
  for i in 0..H {
    h_h.push(Vec::new());
    let mut h = ModInt::new(0, MOD);
    for j in 0..C {
      h *= base;
      h += s[i][j] as isize;
    }
    for j in 0..W - C + 1 {
      h_h[i].push(h);
      let k = j + C;
      if k == W {
        break;
      }
      h -= ModInt::pow_mod(base, C as isize - 1, MOD) * (s[i][j] as isize);
      h *= base;
      h += s[i][k] as isize;
    }
  }

  for j in 0..W - C + 1 {
    let mut h = ModInt::new(0, MOD);
    for i in 0..R {
      h *= base_v;
      h += h_h[i][j];
    }
    for i in 0..H - R + 1 {
      if h == Ph {
        ret.insert((i, j));
      }
      let k = i + R;
      if k == H {
        break;
      }
      h -= ModInt::pow_mod(base_v, R as isize - 1, MOD) * h_h[i][j].n;
      h *= base_v;
      h += h_h[k][j];
    }
  }
  ret
}

use std::ops::{Add, AddAssign, Div, DivAssign, Mul, MulAssign, Sub, SubAssign};

#[derive(Copy, Clone, Debug, PartialEq)]
struct ModInt {
  n: isize,
  MOD: isize,
}
impl ModInt {
  fn new(n: isize, MOD: isize) -> ModInt {
    ModInt {
      n: (n % MOD + MOD) % MOD,
      MOD: MOD,
    }
  }
  fn pow_mod(a: isize, b: isize, MOD: isize) -> isize {
    if b == 0 {
      return 1;
    }
    if b % 2 == 1 {
      return a * ModInt::pow_mod(a, b - 1, MOD) % MOD;
    }
    ModInt::pow_mod(a * a % MOD, b / 2, MOD)
  }
  fn inv(self) -> ModInt {
    let n = ModInt::pow_mod(self.n, self.MOD - 2, self.MOD);
    ModInt::new(n, self.MOD)
  }
}

impl Add for ModInt {
  type Output = ModInt;
  fn add(self, other: ModInt) -> ModInt {
    ModInt::new(self.n + other.n, self.MOD)
  }
}
impl Add<isize> for ModInt {
  type Output = ModInt;
  fn add(self, other: isize) -> ModInt {
    ModInt::new(self.n + other, self.MOD)
  }
}

impl AddAssign for ModInt {
  fn add_assign(&mut self, other: ModInt) {
    self.n = (self.n + other.n) % self.MOD;
  }
}
impl AddAssign<isize> for ModInt {
  fn add_assign(&mut self, other: isize) {
    self.n = (self.n + other) % self.MOD;
  }
}

impl Sub for ModInt {
  type Output = ModInt;
  fn sub(self, other: ModInt) -> ModInt {
    ModInt::new(self.n - other.n, self.MOD)
  }
}
impl Sub<isize> for ModInt {
  type Output = ModInt;
  fn sub(self, other: isize) -> ModInt {
    ModInt::new(self.n - other, self.MOD)
  }
}
impl SubAssign for ModInt {
  fn sub_assign(&mut self, other: ModInt) {
    self.n = (self.n + self.MOD - other.n % self.MOD) % self.MOD;
  }
}
impl SubAssign<isize> for ModInt {
  fn sub_assign(&mut self, other: isize) {
    self.n = (self.n + self.MOD - other % self.MOD) % self.MOD;
  }
}

impl Mul for ModInt {
  type Output = ModInt;
  fn mul(self, other: ModInt) -> ModInt {
    ModInt::new(self.n * other.n, self.MOD)
  }
}
impl Mul<isize> for ModInt {
  type Output = ModInt;
  fn mul(self, other: isize) -> ModInt {
    ModInt::new(self.n * other, self.MOD)
  }
}
impl MulAssign for ModInt {
  fn mul_assign(&mut self, other: ModInt) {
    self.n = self.n * (other.n % self.MOD) % self.MOD;
  }
}
impl MulAssign<isize> for ModInt {
  fn mul_assign(&mut self, other: isize) {
    let o = (other % self.MOD + self.MOD) % self.MOD;
    self.n = self.n * o % self.MOD;
  }
}

impl Div for ModInt {
  type Output = ModInt;
  fn div(self, other: ModInt) -> ModInt {
    other.inv() * self
  }
}
impl Div<isize> for ModInt {
  type Output = ModInt;
  fn div(self, other: isize) -> ModInt {
    ModInt::new(other, self.MOD).inv() * self
  }
}
impl DivAssign for ModInt {
  fn div_assign(&mut self, other: ModInt) {
    *self *= other.inv()
  }
}
impl DivAssign<isize> for ModInt {
  fn div_assign(&mut self, other: isize) {
    *self *= ModInt::pow_mod(other, self.MOD - 2, self.MOD);
  }
}

fn main() {
  let h: usize = read();
  let w: usize = read();
  let mut fields: Vec<Vec<char>> = vec![vec!['0'; w]; h];
  for i in 0..h {
    let line_string: String = read();
    let chars: Vec<char> = line_string.chars().collect();
    for (index, char_data) in chars.iter().enumerate() {
      fields[i][index] = *char_data;
    }
  }
  let r: usize = read();
  let c: usize = read();
  let mut target: Vec<Vec<char>> = vec![vec!['0'; c]; r];
  for i in 0..r {
    let line_string: String = read();
    let chars: Vec<char> = line_string.chars().collect();
    for (index, char_data) in chars.iter().enumerate() {
      target[i][index] = *char_data;
    }
  }

  let ans1 = match_rolling_hash_2d(&fields, &target, 1_000_000_007, 129);
  let ans2 = match_rolling_hash_2d(&fields, &target, 1_000_000_009, 129 + 34);

  let mut ans = ans1.intersection(&ans2).collect::<Vec<_>>();
  ans.sort();
  if ans.len() > 0 {
    println!(
      "{}",
      ans.iter()
        .map(|a| format!("{} {}", a.0, a.1))
        .collect::<Vec<_>>()
        .join("\n")
    );
  }
}
