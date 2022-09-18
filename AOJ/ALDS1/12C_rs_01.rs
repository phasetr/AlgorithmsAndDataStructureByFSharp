// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_12_C/review/5675444/nobuta05/Rust
use std::cmp::Ordering;
use std::collections::{BinaryHeap, HashSet};
use std::io;

#[derive(Debug, Clone)]
struct Edge {
  ed: usize,
  weight: usize,
}

#[derive(Eq)]
struct Node {
  id: usize,
  dist: usize,
}

impl PartialEq for Node {
  fn eq(&self, other: &Node) -> bool {
    self.id == other.id && self.dist == other.dist
  }
}

impl PartialOrd for Node {
  fn partial_cmp(&self, other: &Node) -> Option<Ordering> {
    Some(self.dist.cmp(&other.dist).reverse())
  }
}

impl Ord for Node {
  fn cmp(&self, other: &Node) -> Ordering {
    self.dist.cmp(&other.dist).reverse()
  }
}

fn main() {
  let mut n = String::new();
  io::stdin().read_line(&mut n).unwrap();
  let n: usize = n.trim().parse().unwrap();

  let mut adjlst: Vec<Vec<Edge>> = vec![vec![]; n];
  for _ in 0..n {
    let mut infos = String::new();
    io::stdin().read_line(&mut infos).unwrap();
    let infos: Vec<usize> = infos
      .split_whitespace()
      .map(|info| info.trim().parse().unwrap())
      .collect();
    for k in 0..infos[1] {
      adjlst[infos[0]].push(Edge {
        ed: infos[2 + 2 * k],
        weight: infos[2 + 2 * k + 1],
      });
    }
  }

  let mut dist: Vec<usize> = vec![std::usize::MAX; n];
  let mut s: HashSet<usize> = HashSet::new();
  let mut queue: BinaryHeap<Node> = BinaryHeap::new();
  queue.push(Node { id: 0, dist: 0 });

  while s.len() < n {
    let node = queue.pop().unwrap();
    if !s.contains(&node.id) {
      s.insert(node.id);
      dist[node.id] = node.dist;

      for &Edge { ed, weight } in &adjlst[node.id] {
        if !s.contains(&ed) && dist[node.id] + weight < dist[ed] {
          dist[ed] = dist[node.id] + weight;
          queue.push(Node {
            id: ed,
            dist: dist[ed],
          });
        }
      }
    }
  }

  for i in 0..n {
    println!("{} {}", i, dist[i]);
  }
}
