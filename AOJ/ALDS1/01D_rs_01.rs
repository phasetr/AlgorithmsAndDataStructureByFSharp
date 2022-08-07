// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_1_D/review/3368680/orzz/Rust
use std::io::*;
fn main() {
  let stdin = stdin();
  let mut lines = stdin.lock().lines().map(|l| l.unwrap());

  let n: usize = lines.next().unwrap().parse().unwrap();
  let mut nums = lines.take(n).map(|s| s.parse::<i32>().unwrap());

  let mut max_sub = i32::min_value();
  let mut min_a = nums.next().unwrap();

  for b in nums {
    if b - min_a > max_sub {
      max_sub = b - min_a;
    }
    if b < min_a {
      min_a = b;
    }
  }

  println!("{}", max_sub);
}
