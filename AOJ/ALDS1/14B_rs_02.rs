// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_14_B/review/5999567/boiler2/Rust
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
  let t = read::<String>();
  let p = read::<String>();
  let n = t.len();
  let d = p.len();
  if d > n {
    return;
  }
  for l in 0..n-d+1 {
    let r = l + d;
    if t[l..r] == p {
      println!("{}", l);
    }
  }
}
