// https://algo-method.com/submissions/258653
use std::io;

fn main() {
  let mut n = String::new();
  io::stdin().read_line(&mut n);
  let n: i32 = n.trim().parse().unwrap();

  let mut length = 0;
  for _ in 0..n {
    let mut s = String::new();
    io::stdin().read_line(&mut s);
    length += s.trim().len();
  }
  println!("{}", length);
}
