// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_4_C/review/4118923/phspls/Rust
use std::collections::HashSet;

fn main() {
  let mut n = String::new();
  std::io::stdin().read_line(&mut n).ok();
  let n: usize = n.trim().parse::<usize>().unwrap();

  let mut dict: HashSet<String> = HashSet::new();
  for _ in 0..n {
    let mut op = String::new();
    std::io::stdin().read_line(&mut op).ok();
    let op: Vec<String> = op.trim().split_whitespace().map(|o| o.to_string()).collect();
    match op[0].as_str() {
      "insert" => {
        let val = op[1].to_owned();
        dict.insert(val);
      },
      "find" => {
        if dict.contains(&op[1]) {
          println!("{}", "yes");
        } else {
          println!("{}", "no");
        }
      },
      _ => {},
    }
  }
}
