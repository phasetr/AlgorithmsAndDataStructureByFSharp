// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_3_B/review/5535161/toyoyou/Rust
use std::collections::VecDeque;
use std::io::Read;
fn main() {
  let mut buff = String::new();
  std::io::stdin().read_to_string(&mut buff).unwrap();
  let mut iter = buff.split_whitespace();
  let n: i32 = iter.next().unwrap().parse().unwrap();
  let q: i32 = iter.next().unwrap().parse().unwrap();
  let mut queue: VecDeque<(String, i32)> = VecDeque::with_capacity(n as usize);
  for _ in 0..n {
    let name = iter.next().unwrap().to_string();
    let time = iter.next().unwrap().parse().unwrap();
    queue.push_back((name, time));
  }

  let mut time = 0;
  while !queue.is_empty() {
    time += q;
    let mut p = queue.pop_front().unwrap();
    p.1 -= q;
    if p.1 <= 0 {
      time += p.1;
      println!("{} {}", p.0, time);
    } else {
      queue.push_back(p);
    }
  }
}
