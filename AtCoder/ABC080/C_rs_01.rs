// https://atcoder.jp/contests/abc080/submissions/27895502
use proconio::input;

fn main() {
  input! {
    n: usize,
    f: [[i32; 10]; n],
    p: [[i32; 11]; n],
  }
  let mut fbit = vec![0; n];
  for i in 0..n {
    for j in 0..10 {
      fbit[i] |= f[i][j] << j;
    }
  }
  let mut ans = std::i32::MIN;
  for tmp in 1..1024 {
    let mut profit = 0;
    for i in 0..n {
      profit += p[i][(tmp & fbit[i]).count_ones() as usize];
    }
    ans = ans.max(profit);
  }
  println!("{}", ans);
}
