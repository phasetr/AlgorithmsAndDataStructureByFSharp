// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_9_C/review/4290615/wanimaru/Rust
use std::io;

fn main() {
  let mut n = String::new();
  io::stdin().read_line(&mut n).unwrap();
  let n: i32 = n.trim().parse().unwrap();

  let mut point_a = 0;
  let mut point_b = 0;

  for _ in 0..n {
    let mut words = String::new();
    io::stdin().read_line(&mut words).unwrap();
    let mut iter = words.trim().split_whitespace();

    let s = iter.next().unwrap();
    let t = iter.next().unwrap();

    if s < t {
      point_b += 3;
    } else if s > t {
      point_a += 3;
    } else {
      point_a += 1;
      point_b += 1;
    }
  }

  println!("{} {}", point_a, point_b);
}
