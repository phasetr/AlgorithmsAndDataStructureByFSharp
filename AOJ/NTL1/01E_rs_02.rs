// https://onlinejudge.u-aizu.ac.jp/solutions/problem/NTL_1_E/review/4196118/moshimoshi/Rust
pub fn read<T: std::str::FromStr>() -> T {
  let mut s = String::new();
  std::io::stdin().read_line(&mut s).ok();
  s.trim().parse().ok().unwrap()
}

pub fn read_vec<T: std::str::FromStr>() -> Vec<T> {
  read::<String>()
    .split_whitespace()
    .map(|e| e.parse().ok().unwrap())
    .collect()
}

fn gcd(x: i32, y: i32) -> i32 {
  if y == 0 {
    x
  } else {
    gcd(y, x % y)
  }
}

fn f(p: i32, q: i32) -> (i32, i32) {
  if q == 1 {
    (0, 1)
  } else {
    let r = p / q;
    let s = p % q;
    let (z, w) = f(q, s);
    let x = w;
    let y = z - r * w;
    (x, y)
  }
}

fn main() {
  let ab: Vec<i32> = read_vec();
  let a = ab[0];
  let b = ab[1];
  let g = gcd(a, b);
  let c = a / g;
  let d = b / g;
  let (x, y) = f(c, d);
  println!("{} {}", x, y);
}
