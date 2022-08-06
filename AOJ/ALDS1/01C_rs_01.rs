// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_1_C/review/3367827/orzz/Rust
use std::io::*;

fn main() {
  let stdin = stdin();
  let mut lines = stdin.lock().lines().map(|l| l.unwrap());

  let n = lines.next().unwrap().parse().unwrap();
  let nums = lines.take(n).map(|s| s.parse::<u32>().unwrap());

  let count = nums.filter(|&num| {
    if num == 2 {
      true
    }
    else if num % 2 == 0 {
      false
    }
    else {
      let end = (num as f64).sqrt().floor() as u32;

      for i in (1 .. (end + 1) / 2) {
        if num % (i * 2 + 1) == 0 {
          return false
        }
      }
      true
    }
  }).count();

  println!("{}", count);
}
