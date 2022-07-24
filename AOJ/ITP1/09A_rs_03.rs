// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_9_A/review/2750683/enji/Rust
use std::io::BufRead;

fn main() {
  let stdin = std::io::stdin();
  let mut buf = String::new();
  stdin.read_line(&mut buf).unwrap();

  let word = buf.trim();
  let mut cnt = 0;
  for line in stdin.lock().lines() {
    let line = line.unwrap();
    let line = line.trim();
    if line == "END_OF_TEXT" {
      break;
    }
    cnt += line.split_whitespace().filter(|&x| x.to_lowercase() == word).count();
  }
  println!("{}", cnt);
}
