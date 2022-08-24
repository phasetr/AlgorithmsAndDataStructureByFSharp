// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_4_B/review/5923550/boiler2/Rust
use std::io::*;
use std::str::FromStr;

fn read<T: FromStr>() -> T {
  let s = stdin();
  let s = s.lock();
  let s: String = s.bytes()
    .map(|c| c.expect("failed reading char") as char)
    .skip_while(|c| c.is_whitespace())
    .take_while(|c| !c.is_whitespace())
    .collect();
  s.parse().ok().expect("failed parsing")
}

fn main() {
  let n: usize = read();
  let mut s = vec![0; n];
  for i in 0..n {
    s[i] = read();
  }
  let q: usize = read();
  let mut t = vec![0; q];
  for j in 0..q {
    t[j] = read();
  }
  let mut ans = 0;
  for j in 0..q {
    match s.binary_search(&t[j]) {
      Ok(_) => ans += 1,
      Err(_) => {},
    }
  }
  println!("{}", ans);
}
