// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_9_D/review/2750813/enji/Rust
use std::io::BufRead;

fn main() {
  let stdin = std::io::stdin();
  let mut lines = stdin.lock().lines();

  let mut str = lines.next().unwrap().unwrap().to_string();
  let n = lines.next().unwrap().unwrap().parse::<usize>().unwrap();

  for line in lines.take(n) {
    let line = line.unwrap();
    let mut ite = line.split_whitespace();
    let command = ite.next().unwrap();
    let a = ite.next().unwrap().parse::<usize>().unwrap();
    let b = ite.next().unwrap().parse::<usize>().unwrap();

    match command {
      "replace" => {
        let w = ite.next().unwrap();
        str.drain(a..b+1);
        str.insert_str(a, &w);
      }
      "reverse" => {
        let rev = str.drain(a..b+1).rev().collect::<String>();
        str.insert_str(a, &rev);
      }
      "print" => {
        println!("{}", &str[a..b+1]);
      }
      _ => { }
    }
  }
}
