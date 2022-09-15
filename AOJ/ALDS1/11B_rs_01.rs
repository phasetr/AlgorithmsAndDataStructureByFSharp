// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_11_B/review/5927403/boiler2/Rust
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

fn dfs(
  graph: &Vec<Vec<usize>>,
  seen: &mut Vec<bool>,
  u: usize,
  t: &mut usize,
  st: &mut Vec<usize>,
  et: &mut Vec<usize>,
){
  *t += 1;
  st[u] = *t;
  seen[u] = true;
  for &v in &graph[u] {
    if !seen[v] {
      dfs(graph, seen, v, t, st, et);
    }
  }
  *t += 1;
  et[u] = *t;
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
  let mut seen = vec![false; n];
  let mut t = 0;
  let mut st = vec![0; n];
  let mut et = vec![0; n];
  for i in 0..n {
    if !seen[i] {
      dfs(&graph, &mut seen, i, &mut t, &mut st, &mut et);
    }
  }
  for i in 0..n {
    println!("{} {} {}", i+1, st[i], et[i]);
  }
}
