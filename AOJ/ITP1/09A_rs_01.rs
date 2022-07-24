// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_9_A/review/4285589/wanimaru/Rust
use std::io;

fn main() {
  let mut s = String::new();
  io::stdin().read_line(&mut s).unwrap();
  s = s.trim().to_string();

  let mut t: Vec<String> = vec![];

  loop {
    let mut s = String::new();
    io::stdin().read_line(&mut s).unwrap();
    if s.find("END_OF_TEXT") != None {
      break;
    }
    for term in s.to_lowercase().trim().split_whitespace() {
      t.push(term.to_string())
    }
  }

  let mut ans = 0;
  for term in t {
    if term == s {
      ans += 1;
    }
  }
  println!("{}", ans);
}
