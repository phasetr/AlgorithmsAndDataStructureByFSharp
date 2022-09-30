// https://onlinejudge.u-aizu.ac.jp/solutions/problem/NTL_1_B/review/5739503/kinodjnz/Rust
use std::io::Read;

const M: i64 = 1000000007;

fn modpow(mut m: i64, mut n: i64, d: i64) -> i64 {
  let mut r: i64 = 1;
  while n > 0 {
    if n % 2 == 1 {
      r = r * m % d;
    }
    m = m * m % d;
    n >>= 1;
  }
  r
}

fn main() {
  let mut buf = String::new();
  std::io::stdin().read_to_string(&mut buf).unwrap();
  let mut iter = buf.split_whitespace();
  let m: i64 = iter.next().unwrap().parse().unwrap();
  let n: i64 = iter.next().unwrap().parse().unwrap();
  let ans = modpow(m, n, M);
  println!("{}", ans);
}
