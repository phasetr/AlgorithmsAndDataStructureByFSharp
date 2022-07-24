// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_8_D/review/4285424/wanimaru/Rust
use std::io;

fn main() {
  let mut s = String::new();
  io::stdin().read_line(&mut s).unwrap();
  s = s.trim().to_string();
  s = s.clone() + &s;

  let mut t = String::new();
  io::stdin().read_line(&mut t).unwrap();
  let t = t.trim();

  let ans = match &s.find(t) {
    &Some(_) => "Yes",
    _ => "No"
  };

  println!("{}", ans);
}
