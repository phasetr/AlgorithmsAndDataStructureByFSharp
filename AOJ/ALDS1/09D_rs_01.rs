// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_9_D/review/5446571/boiler2/Rust
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

  a.sort();
  for i in 0..n-1 {
    let mut j = i;
    while j > 0 {
      let k = (j-1)/2;
      a.swap(j,k);
      j = k;
    }
    a.swap(0,i+1);
  }

  let a: Vec<String> = a.iter().map(|v| v.to_string()).collect();
  println!("{}", a.join(" "));
}
