// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_4_A/review/4348789/orzz/Rust
use std::io::*;

fn main() {
  let input = {
    let mut buf = vec![];
    stdin().read_to_end(&mut buf);
    unsafe { String::from_utf8_unchecked(buf) }
  };
  let mut lines = input.split('\n');

  let input = lines.nth(1).unwrap();
  let s_vec: Vec<u32> = input.split(' ').map(|s| s.parse().unwrap()).collect();

  let input = lines.nth(1).unwrap();
  let t_iter = input.split(' ').map(|s| s.parse::<u32>().unwrap());

  let c = t_iter.filter(|i| s_vec.contains(i)).count();

  println!("{}", c);
}
