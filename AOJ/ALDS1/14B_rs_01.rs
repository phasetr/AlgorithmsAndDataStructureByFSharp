// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_14_B/review/6054054/kyotoku1483/Rust
fn main() {
  let t: String = read();
  let p: String = read();
  if t.len() < p.len() {
    return;
  }
  for i in 0..=t.len() - p.len() {
    if &t[i..i + p.len()] == p {
      println!("{}", i);
    }
  }
}
#[allow(dead_code)]
fn read<T: std::str::FromStr>() -> T {
  let mut s = String::new();
  std::io::stdin().read_line(&mut s).ok();
  s.trim().parse().ok().unwrap()
}

#[allow(dead_code)]
fn read_vec<T: std::str::FromStr>() -> Vec<T> {
  read::<String>()
    .split_whitespace()
    .map(|e| e.parse().ok().unwrap())
    .collect()
}

#[allow(dead_code)]
fn read_vec2<T: std::str::FromStr>(n: u32) -> Vec<Vec<T>> {
  (0..n).map(|_| read_vec()).collect()
}
