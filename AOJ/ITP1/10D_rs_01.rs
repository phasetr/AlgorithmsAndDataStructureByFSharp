// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_10_D/review/2751153/enji/Rust
use std::io::BufRead;
use std::cmp::PartialOrd;

fn main() {
  let stdin = std::io::stdin();
  let mut lines = stdin.lock().lines();

  let n = lines.next().unwrap().unwrap()
    .parse::<usize>().unwrap();

  let vec_x = lines.next().unwrap().unwrap()
    .split_whitespace()
    .map(|x| x.parse::<f64>().unwrap())
    .collect::<Vec<_>>();

  let vec_y = lines.next().unwrap().unwrap()
    .split_whitespace()
    .map(|x| x.parse::<f64>().unwrap())
    .collect::<Vec<_>>();

  for p in 1..3+1 {
    let sum = vec_x.iter().zip(vec_y.iter())
      .map(|(x, y)| (x - y).abs().powi(p))
      .sum::<f64>();
    println!("{}", sum.powf(1. / (p as f64)));
  }

  let max = vec_x.iter().zip(vec_y.iter())
    .map(|(x, y)| (x - y).abs())
    .fold(0.0f64, |acc, x| acc.max(x));

  println!("{}", max);
}
