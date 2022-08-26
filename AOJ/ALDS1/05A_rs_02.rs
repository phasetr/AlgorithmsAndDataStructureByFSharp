// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_5_A/review/5920357/boiler2/Rust
use std::io::*;
use std::str::FromStr;

fn read<T: FromStr>() -> T {
  let s = stdin();
  let s = s.lock();
  let s: String = s.bytes()
    .map(|c| c.expect("failed reading char") as char)
    .skip_while(|c| c.is_whitespace())
    .take_while(|c| !c.is_whitespace())
    .collect();
  s.parse().ok().expect("failed parsing")
}

fn main() {
  let n: usize = read();
  let mut a = vec![0; n];
  for i in 0..n {
    a[i] = read();
  }
  let m: usize = read();
  let mut b = vec![0; m];
  for j in 0..m {
    b[j] = read();
  }
  let mut ans = vec![false; m];
  for state in 0..1<< n {
    let mut sum = 0;
    for i in 0..n {
      if state & 1 << i > 0 {
        sum += a[i];
      }
    }
    for j in 0..m {
      if b[j] == sum {
        ans[j] = true;
      }
    }
  }
  for j in 0..m {
    println!("{}", if ans[j] { "yes" } else { "no" });
  }
}
