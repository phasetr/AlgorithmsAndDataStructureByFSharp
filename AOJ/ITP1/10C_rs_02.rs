// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_10_C/review/2739103/orzz/Rust
use std::io::*;

fn main() {
  let stdin = stdin();
  let mut lines = stdin.lock().lines();

  loop {
    let n = lines.next().unwrap().unwrap().parse::<f64>().unwrap();
    if n == 0.0 { break; }

    let data = lines.next().unwrap().unwrap()
      .split_whitespace()
      .map(|s| s.parse::<f64>().unwrap())
      .collect::<Vec<_>>();

    let avg = data.iter().sum::<f64>() / n;
    let sd = (data.into_iter().fold(0.0, |acc, s| acc + (s - avg).powi(2)) / n).sqrt();

    println!("{}", sd);
  }
}
