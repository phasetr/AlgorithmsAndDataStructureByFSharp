// https://atcoder.jp/contests/agc043/submissions/30372312
use proconio::{input};
use proconio::marker::Chars;

fn main() {
  input!{h:usize,w:usize,shw:[Chars;h]}
  let mut dp = vec![vec![1<<30;w+1];h+1];
  dp[0][0] = if shw[0][0] == '.' {0} else {1};
  for i in 1..h{
    dp[i][0] = dp[i-1][0] + if shw[i][0] == '.' || shw[i-1][0] == shw[i][0] {0} else {1};
  }
  for i in 1..w{
    dp[0][i] = dp[0][i-1] + if shw[0][i] == '.' || shw[0][i-1] == shw[0][i] {0} else {1};
  }
  for i in 1..h{
    for j in 1..w{
      dp[i][j] = (dp[i-1][j] + if shw[i][j] == '.' || shw[i-1][j] == shw[i][j] {0} else {1}).min(dp[i][j-1] + if shw[i][j] == '.' || shw[i][j-1] == shw[i][j]  {0} else {1});
    }
  }
  println!("{}",dp[h-1][w-1]);
}
