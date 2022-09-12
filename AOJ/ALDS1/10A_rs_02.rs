// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_10_A/review/5930196/boiler2/Rust
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
  let mut dp = vec![0; n+1];
  dp[0] = 1;
  dp[1] = 1;
  for i in 2..=n {
    dp[i] = dp[i-1] + dp[i-2];
  }
  println!("{}", dp[n]);
}
