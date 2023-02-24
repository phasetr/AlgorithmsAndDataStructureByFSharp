// https://algo-method.com/submissions/413830
fn main() {
  let ref mut s = String::new();
  std::io::stdin().read_line(s);
  print!("{}", s.chars().nth(2).unwrap());
}
