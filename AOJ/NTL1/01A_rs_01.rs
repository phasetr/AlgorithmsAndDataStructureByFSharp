// https://onlinejudge.u-aizu.ac.jp/solutions/problem/NTL_1_A/review/5943982/boiler2/Rust
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
  print!("{}:", n);
  let mut i = 2;
  let mut m = n;
  while i * i <= n {
    while m % i == 0 {
      print!(" {}", i);
      m /= i;
    }
    i += 1;
  }
  if m != 1 {
    print!(" {}", m);
  }
  println!();
}
