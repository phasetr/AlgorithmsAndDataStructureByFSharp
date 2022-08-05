// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_1_B/review/2756251/MitI7/Rust
use std::io;

fn main() {
  let mut x = String::new();
  io::stdin().read_line(&mut x).unwrap();
  let x: i32 = x.trim().parse().unwrap();
  println!("{}", x * x * x);
}
