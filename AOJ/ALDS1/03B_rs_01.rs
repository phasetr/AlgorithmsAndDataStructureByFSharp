// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_3_B/review/4347757/orzz/Rust
use std::io::*;

fn main() {
  let input = {
    let mut buf = vec![];
    stdin().read_to_end(&mut buf);
    unsafe { String::from_utf8_unchecked(buf) }
  };
  let mut lines = input.split('\n');

  let (n, q): (usize, u32) = {
    let line = lines.next().unwrap();
    let mut iter = line.split(' ');
    (
      iter.next().unwrap().parse().unwrap(),
      iter.next().unwrap().parse().unwrap(),
    )
  };

  let mut queue = std::collections::VecDeque::with_capacity(n);

  let iter = lines.take(n).map(|l| {
    let mut iter = l.split(' ');
    (
      iter.next().unwrap(),
      iter.next().unwrap().parse::<u32>().unwrap(),
    )
  });
  queue.extend(iter);

  let mut total = 0;

  while let Some((name, time)) = queue.pop_front() {
    if time <= q {
      total += time;
      println!("{} {}", name, total);
    } else {
      total += q;
      queue.push_back((name, time - q));
    }
  }
}
