// https://atcoder.jp/contests/diverta2019/submissions/28039292
use num_integer::Integer;
use proconio::input;

fn main() {
  input!{ n: i64, }
  let mut ans = 0;
  for r in 1.. {
    if r*r + r >= n { break; }
    if let (m, 0) = (n-r).div_rem(&r) {
      ans += m;
    }
  }
  println!("{}", ans);
}
