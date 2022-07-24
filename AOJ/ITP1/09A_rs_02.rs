// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_9_A/review/2738560/orzz/Rust
use std::io::*;

fn main() {
  let stdin = stdin();
  let mut lines = stdin.lock().lines();

  let word = lines.next().unwrap().unwrap().to_lowercase();

  let mut count = 0;

  for line in lines {
    let line = line.unwrap();
    if line == "END_OF_TEXT" { break; }

    let line = line.to_lowercase();
    let words = line.split_whitespace();

    count += words.filter(|&w| w == word).count();
  }
  println!("{}", count);
}
