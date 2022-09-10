// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_9_A/review/5446440/boiler2/Rust
use std::io::*;
use std::str::FromStr;

fn rin<T: FromStr>() -> T {
  let s: Stdin = stdin();
  let s: StdinLock = s.lock();
  let s: String = s.bytes()
    .map(|c| c.expect("failed reading char.") as char)
    .skip_while(|c| c.is_whitespace())
    .take_while(|c| !c.is_whitespace())
    .collect();
  s.parse().ok().expect("faild parsing.")
}

fn main() {
  let n: usize = rin();
  let mut a: Vec<i32> = vec![0; n];
  for i in 0..n { a[i] = rin(); }

  for i in 1..=n {
    print!("node {}: key = {},", i, a[i-1]);
    if i/2 >= 1 {
      print!(" parent key = {},", a[i/2-1]);
    }
    if i*2 <= n {
      print!(" left key = {},", a[i*2-1]);
    }
    if i*2+1 <= n {
      print!(" right key = {},", a[i*2]);
    }
    println!();
  }
}
