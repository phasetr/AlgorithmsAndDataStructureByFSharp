// https://atcoder.jp/contests/abc070/submissions/23021843
use proconio::{fastout, input};
use petgraph::algo::dijkstra;
use petgraph::graph::{NodeIndex, UnGraph};

#[fastout]
fn main() {
   input! {
      n: usize,
      edges: [(usize, usize, usize); n-1],
      q: usize,
      k: usize,
      pairs: [(usize, usize); q],
   }

   let g = UnGraph::<usize, usize, usize>::from_edges(&edges);
   let dist = dijkstra(&g, NodeIndex::new(k), None, |e| *e.weight());

   for (start, end) in &pairs {
      let s = dist.get(&NodeIndex::new(*start)).unwrap();
      let e = dist.get(&NodeIndex::new(*end)).unwrap();
      println!("{}", s + e);
   }
}
