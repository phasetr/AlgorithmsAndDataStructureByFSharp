// https://atcoder.jp/contests/abc107/submissions/28083365
use proconio::{input, fastout};

#[fastout]
fn main() {
  input!{
    n: usize, k: usize,
    x: [i32; n],
  }
  let ans = (0..=n-k)
    .into_iter()
    .map(|i| x[i+k-1] - x[i] + x[i+k-1].abs().min(x[i].abs()))
    .min().unwrap();
  println!("{}", ans);
}

