// https://algo-method.com/submissions/416242
use std::io::stdin;
fn main() {
  let ref mut s = String::new();
  stdin().read_line(s);
  stdin().read_line(s);
  let s: u32 = s.split_whitespace()
    .skip(1)
    .map(|s| s.parse::<u32>().unwrap())
    .sum();
  print!("{}", s);
}
