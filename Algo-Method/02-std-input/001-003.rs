// https://algo-method.com/submissions/848771
use std::io;

fn main() {
  let mut input = String::new();
  io::stdin().read_line(&mut input).expect("Failed to read line");
  let s = input.trim().to_string();
  println!("{}", s.repeat(3));
}
