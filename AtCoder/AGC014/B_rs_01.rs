// https://atcoder.jp/contests/agc014/submissions/28020383
use num_integer::Integer;
use proconio::input;

fn main() {
  input! {
    n: usize, m: usize,
    ab: [usize; 2*m],
  }
  let mut cnt = vec![0; n+1];
  ab.into_iter().for_each(|x| cnt[x] += 1);
  let ans = cnt.iter().all(|x| x.is_even());
  println!("{}", if ans {"YES"} else {"NO"});
}
