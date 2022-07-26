// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_9_B/review/2738580/orzz/Rust
use std::io::*;

fn main() {
  let stdin = stdin();
  let mut lines = stdin.lock().lines();

  loop {
    let mut str = lines.next().unwrap().unwrap();
    if str == "-" { break; }

    let m = lines.next().unwrap().unwrap().parse::<usize>().unwrap();
    let h: usize = lines.by_ref().take(m).map(|l| l.unwrap().parse::<usize>().unwrap()).sum();

    let (a, b) = str.split_at(h % str.len());
    println!("{}{}", b, a);
  }
}
