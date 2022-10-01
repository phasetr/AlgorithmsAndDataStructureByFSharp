// https://onlinejudge.u-aizu.ac.jp/solutions/problem/NTL_1_D/review/6302857/bit_AOJ/Rust
use std::io;
fn main() {
  let mut number = String::new();
  io::stdin().read_line(&mut number).ok();
  let n = number.trim().parse().ok().unwrap();
  println!("{}", phi(n));
}

fn phi(const_n: i64) -> i64 {
  let mut n = const_n;
  let mut d = 2;
  let mut div = Vec::new();
  while d * d <= n {
    if n % d == 0 {
      div.push(d);
      while n % d == 0 {
        n /= d;
      }
    }
    d += 1;
  }
  if n != 1 {
    div.push(n);
  }

  let m = div.len();
  let mut res = 0;
  for bit in 0_u64..1<<m {
    let popcnt = bit.count_ones();
    let mut mul = 1;
    for i in 0..m {
      if bit >> i & 1 != 0 {
        mul *= div[i];
      }
    }
    if popcnt % 2 == 0 {
      res += const_n / mul;
    }
    else {
      res -= const_n / mul;
    }
  }
  res
}
