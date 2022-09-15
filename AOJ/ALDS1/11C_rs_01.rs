// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_11_C/review/5927538/boiler2/Rust
use std::collections::VecDeque;
use std::io::*;
use std::str::FromStr;

fn read<T: FromStr>() -> T {
  let s = stdin();
  let s = s.lock();
  let s: String = s.bytes()
    .map(|c| c.expect("failed reading char") as char)
    .skip_while(|c| c.is_whitespace())
    .take_while(|c| !c.is_whitespace())
    .collect();
  s.parse().ok().expect("failed parsing")
}

fn bfs(
  n: usize,
  graph: &Vec<Vec<usize>>,
) -> Vec<i64> {
  let mut dist = vec![-1; n];
  let mut que = VecDeque::new();
  dist[0] = 0;
  que.push_back(0);
  while let Some(u) = que.pop_front() {
    for &v in &graph[u] {
      if dist[v] == -1 {
        dist[v] = dist[u] + 1;
        que.push_back(v);
      }
    }
  }
  dist
}

fn main() {
  let n: usize = read();
  let mut graph = vec![vec![]; n];
  for _ in 0..n {
    let u: usize = read();
    let k: usize = read();
    for _ in 0..k {
      let v: usize = read();
      graph[u-1].push(v-1);
    }
  }
  let dist = bfs(n, &graph);
  for (i, &v) in dist.iter().enumerate() {
    println!("{} {}", i+1, v);
  }
}
