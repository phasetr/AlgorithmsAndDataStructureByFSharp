// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_3_C/review/4872092/tjnt/Rust
use std::collections::VecDeque;

pub fn read<T: std::str::FromStr>() -> T {
  let mut s = String::new();
  std::io::stdin().read_line(&mut s).ok();
  s.trim().parse().ok().unwrap()
}

pub fn read_vec<T: std::str::FromStr>() -> Vec<T> {
  read::<String>()
    .split_whitespace()
    .map(|e| e.parse().ok().unwrap())
    .collect()
}

fn main() {
  let n: usize = read();
  let mut list = VecDeque::new();
  for _ in 0..n {
    let s = read_vec::<String>();
    match &s[0][..] {
      "insert" => {
        list.push_front(s[1].to_string());
      },
      "delete" => {
        list.iter().position(|e| *e == s[1])
          .map(|i| Some(list.remove(i)));
      },
      "deleteFirst" => { list.pop_front(); },
      "deleteLast"  => { list.pop_back(); },
      _ => panic!()
    };
  }
  println!(
    "{}",
    list.into_iter().map(|e| e.to_string()).collect::<Vec<_>>().join(" "));
}
