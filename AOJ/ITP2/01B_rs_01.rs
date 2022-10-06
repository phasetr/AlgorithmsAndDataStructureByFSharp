// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP2_1_B/review/5049791/y61mpnl/Rust
use std::collections::VecDeque;

fn readi() -> Vec<i32> {
  let mut s = String::new();
  std::io::stdin().read_line(&mut s).unwrap();
  s.split_whitespace().map(|x| x.parse::<i32>().unwrap()).collect()
}

fn main() {
  let mut deq = VecDeque::<i32>::new();

  let mut q = readi()[0];
  while q>0 {
    let query = readi();
    match query[0] {
      0 => {
        if query[1]==0 {
          deq.push_front(query[2]);
        } else {
          deq.push_back(query[2]);
        }
      },
      1 => {
        println!("{}", deq[query[1] as usize]);
      },
      2 => {
        if query[1]==0 {
          deq.pop_front();
        } else {
          deq.pop_back();
        }
      },
      _ => ()
    }
    q -= 1;
  }
}
