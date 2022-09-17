// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_12_B/review/4879752/ei1710/Rust
#![allow(dead_code)]
pub struct Scanner {
  idx: usize,
  buf: Vec<String>,
}

impl Scanner {
  pub fn new<T: std::io::Read>(inf: &mut T) -> Scanner {
    Self {
      idx: 0,
      buf: {
        let mut s = String::new();
        inf.read_to_string(&mut s).expect("I/O error");
        s.split_whitespace().map(|x| x.to_owned()).collect()
      },
    }
  }

  pub fn read<T: std::str::FromStr>(&mut self) -> T
  where
    <T as std::str::FromStr>::Err: std::fmt::Debug,
  {
    if self.empty() {
      panic!("reached the end of input")
    }
    let ret = self.buf[self.idx].parse::<T>().expect("parse error");
    self.idx += 1;
    return ret;
  }

  pub fn empty(&self) -> bool {
    return self.idx >= self.buf.len();
  }
}

fn dijkstra(s: usize, g: &Vec<Vec<(usize, u64)>>) -> Vec<u64> {
  use std::collections::binary_heap::BinaryHeap;
  use std::cmp::Reverse;

  let inf = 1 << 60;
  let mut min_cost = vec![inf; g.len()];
  let mut p_que = BinaryHeap::new();
  p_que.push(Reverse((0, s)));

  while !p_que.is_empty() {
    let (cost, pos) = p_que.pop().unwrap().0;

    if min_cost[pos] != inf { continue; }
    min_cost[pos] = cost;

    for (to, cos) in &g[pos] {
      if min_cost[*to] <= cost + cos { continue; }
      p_que.push(Reverse((cost + cos, *to)));
    }
  }

  return min_cost;
}

fn main() {
  let mut sc = Scanner::new(&mut std::io::stdin());
  let n: usize = sc.read();
  let mut g = vec![Vec::new(); n];

  for _ in 0..n {
    let uid: usize = sc.read();
    let k: usize = sc.read();
    for _ in 0..k {
      let v: usize = sc.read();
      let cost: u64 = sc.read();
      g[uid].push((v, cost));
    }
  }

  let mc = dijkstra(0, &g);
  for (i, val) in mc.iter().enumerate() {
    println!("{} {}", i, val);
  }
}
