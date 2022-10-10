// https://onlinejudge.u-aizu.ac.jp/solutions/problem/GRL_1_A/review/4181448/s1190170/Rust
use std::io::*;
use std::vec::*;
use std::collections::BinaryHeap;

fn dijkstra(graph: &Vec<Vec<(usize, i64)>>, start: usize) -> Vec<i64> {
  let mut dist = vec![-(1 << 62); graph.len()];
  let mut heap = BinaryHeap::new();
  dist[start] = 0;
  heap.push((0, start));
  while let Some((acc, pos)) = heap.pop() {
    if dist[pos] > acc { continue; }
    for &(dst, cost) in &graph[pos] {
      if acc + cost > dist[dst] {
        dist[dst] = acc + cost;
        heap.push((acc + cost, dst));
      }
    }
  }
  return dist;
}

fn main(){
  let mut input = String::new();
  let _ = stdin().read_line(&mut input);

  let nums: Vec<i32> = input.split_whitespace().map(|e| e.parse().unwrap()).collect();
  let v = nums[0] as usize;
  let e = nums[1];
  let r = nums[2];

  let mut graph = vec![vec![]; v];

  for _ in 0..e {
    let mut input = String::new();
    let _ = stdin().read_line(&mut input);
    let edge: Vec<i64> = input.split_whitespace().map(|e| e.parse().unwrap()).collect();
    let s = edge[0] as usize;
    let t = edge[1] as usize;
    let d = edge[2];
    graph[s].push((t, -d));
  }

  for d in dijkstra(&graph, r as usize) {
    if d <= -(1 << 62) {
      println!("INF");
    } else {
      println!("{}", -d);
    }
  }
}
