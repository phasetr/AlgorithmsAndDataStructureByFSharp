// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_10_B/review/2750896/enji/Rust
use std::f64::consts::PI;

fn main() {
  let stdin = std::io::stdin();
  let mut buf = String::new();
  stdin.read_line(&mut buf).unwrap();

  let mut ite = buf.trim().split_whitespace()
    .map(|x| x.parse::<f64>().unwrap());

  let a = ite.next().unwrap();
  let b = ite.next().unwrap();
  let c = ite.next().unwrap();

  let rad = c.to_radians();

  println!("{}", a * b * rad.sin() * 0.5);
  println!("{}", (a.powi(2) + b.powi(2) - 2. * a * b * rad.cos()).sqrt() + a + b);
  println!("{}", b * rad.sin());
}
