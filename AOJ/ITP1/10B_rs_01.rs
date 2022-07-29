// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_10_B/review/4293099/wanimaru/Rust
use std::io;

fn main() {
  let mut s = String::new();
  io::stdin().read_line(&mut s).unwrap();
  let mut iter = s.trim().split_whitespace();

  let a: f64 = iter.next().unwrap().parse().unwrap();
  let b: f64 = iter.next().unwrap().parse().unwrap();
  let c: f64 = iter.next().unwrap().parse().unwrap();

  let h = b * c.to_radians().sin();
  let s = a * h / 2.;
  let l = a + b + ((a - b * c.to_radians().cos()).powi(2) + h.powi(2)).sqrt();

  println!("{}\n{}\n{}", s, l, h);
}
