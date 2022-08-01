// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_11_B/review/2740136/orzz/Rust
use std::io::*;

struct Dice;

impl Dice {
  fn right_of(top: usize, front: usize) -> usize {
    let (a, b) = (top > 2, front > 2);

    let t = if a { 5 - top } else { top };
    let f = if b { 5 - front } else { front };

    let right = match (t, f) {
      (0, 1) => 2,
      (1, 2) => 0,
      (2, 0) => 1,
      (1, 0) => 3,
      (2, 1) => 5,
      (0, 2) => 4,
      _ => unreachable!()
    };

    if a ^ b { 5 - right } else { right }
  }
}

fn main() {
  let stdin = stdin();
  let mut lines = stdin.lock().lines();

  let line = lines.next().unwrap().unwrap();
  let labels = line.split_whitespace().collect::<Vec<_>>();
  let q = lines.next().unwrap().unwrap().parse::<usize>().unwrap();

  for _ in 0..q {
    let line = lines.next().unwrap().unwrap();
    let mut args = line.split_whitespace();

    let top = args.next().unwrap();
    let front = args.next().unwrap();

    let top = labels.iter().position(|&x| x == top).unwrap();
    let front = labels.iter().position(|&x| x == front).unwrap();

    let right = Dice::right_of(top, front);

    println!("{}", labels[right]);
  }
}
