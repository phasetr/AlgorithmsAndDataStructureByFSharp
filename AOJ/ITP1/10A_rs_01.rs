// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_10_A/review/4293221/wanimaru/Rust
use std::io;

fn main() {
  let mut s = String::new();
  io::stdin().read_line(&mut s).unwrap();
  let p: Vec<f64> = s.trim().split_whitespace().map(|x| x.parse().unwrap()).collect::<_>();
  let ans = ((p[0] - p[2]).powi(2) + (p[1] - p[3]).powi(2)).sqrt();
  println!("{}", ans);
}
