// https://algo-method.com/submissions/413831
fn main() {
  let ref mut s = String::new();
  std::io::stdin().read_line(s);
  let s: u8 = s.split_whitespace()
    .map(|s| s.parse::<u8>().unwrap())
    .sum();
  print!("{}", s);
}
