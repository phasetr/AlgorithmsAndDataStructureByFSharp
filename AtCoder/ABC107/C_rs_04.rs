// https://atcoder.jp/contests/abc107/submissions/22729214
use proconio::input;
use std::cmp::min;
fn main() {
  input!{
    n: usize,
    mut k: usize,
    xs: [i64; n]
  };
  let mut ans = 1 << 60;
  for i in 0..=(n-k) {
    let d = xs[i+k-1] - xs[i];
    ans = min(ans, d+xs[i].abs());
    ans = min(ans, d+xs[i+k-1].abs());
  }
  println!("{}",ans);
}
