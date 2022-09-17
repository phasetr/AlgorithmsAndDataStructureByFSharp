// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_12_A/review/6641342/Lm005/Rust
use std::io;
use std::io::Read;

fn main() {
  let mut buf = String::new();
  io::stdin().read_to_string(&mut buf).unwrap();
  let mut iter = buf.split_whitespace();

  let n: usize = iter.next().unwrap().parse().unwrap();
  let mut g = vec![vec![0; n]; n];

  for i in 0..n {
    for j in 0..n {
      g[i][j] = iter.next().unwrap().parse().unwrap();
    }
  }

  let mut edges: Vec<(usize, usize, usize)> = Vec::new();

  for i in 0..n - 1 {
    for j in i..n {
      if g[i][j] != -1 {
        edges.push((g[i][j] as usize, i, j));
      }
    }
  }

  edges.sort();

  let mut nodes: Vec<usize> = (0..n).collect();
  let mut ans = 0;

  for edge in edges {
    if root(edge.1, &nodes) != root(edge.2, &nodes) {
      ans += edge.0;
      let root_1 = root(edge.1, &nodes);
      nodes[root_1] = root(edge.2, &nodes);
    }
  }

  println!("{}", ans);
}

fn root(x: usize, nodes: &Vec<usize>) -> usize {
  let mut parent = x;
  while parent != nodes[parent] {
    parent = nodes[parent]
  }
  return parent;
}
