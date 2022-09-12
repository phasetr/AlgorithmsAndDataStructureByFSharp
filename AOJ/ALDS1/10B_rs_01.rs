// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_10_B/review/5933493/boiler2/Rust
use std::cmp::min;
use std::io::*;
use std::str::FromStr;
use std::usize::MAX;

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
  let mut p = vec![0; n+1];
  for i in 0..n {
    p[i] = read();
    p[i+1] = read();
  }
  let mut dp = vec![vec![0; n+1]; n+1];
  for d in 1..=n {
    for l in 1..1+n-d {
      let r = l+d;
      dp[l][r] = MAX;
      for k in l..r {
        dp[l][r] = min(dp[l][r], dp[l][k] + dp[k+1][r] + p[l-1] * p[k] * p[r]);
      }
    }
  }
  println!("{}", dp[1][n]);
}
