// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_9_C/review/4149850/phspls/Rust
use std::collections::BinaryHeap;

fn main() {
  let mut values: BinaryHeap<usize> = BinaryHeap::new();
  loop {
    let mut op = String::new();
    std::io::stdin().read_line(&mut op).ok();
    let op: Vec<&str> = op.trim().split_whitespace().collect();
    match op[0] {
      "insert" => { let val: usize = op[1].parse().unwrap(); values.push(val); },
      "extract" => { println!("{}", values.pop().unwrap()); },
      "end" => { break; },
      _ => { },
    }
  }
}
