// https://atcoder.jp/contests/abc107/submissions/22171054
use proconio::input;
use std::cmp::min;

fn main() {
  input!{
    n:usize,k:usize,
    xn:[isize;n]
  }
  let mut ans = 1 << 60;
  for l in 0..(n-k+1){
    let r = l+k-1;
    ans = min(ans,min(xn[l as usize].abs(),xn[r].abs())+(xn[r]-xn[l]));
  }
  println!("{}",ans);
}
