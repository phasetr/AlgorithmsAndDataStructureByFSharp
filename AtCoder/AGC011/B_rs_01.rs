// https://atcoder.jp/contests/agc011/submissions/22305298
use proconio::input;

fn main() {
  input!{
    n:usize,
    mut a:[usize;n],
  }
  a.sort();
  let mut ans = 0;
  let mut t = 0;
  for i in &a{
    if t*2 < *i {
      ans = 1;
    } else {
      ans += 1;
    }
    t += *i;
  }
  println!("{}",ans);
}
