// https://atcoder.jp/contests/abc070/submissions/28972252
#![allow(unused_imports, non_snake_case)]
use proconio::{*, marker::*};
use std::cmp::{max, min};
use std::collections::{VecDeque, HashMap, BTreeMap, HashSet, BTreeSet};
use itertools::Itertools;
use superslice::Ext;
use petgraph::graph::{NodeIndex, UnGraph};
use petgraph::algo::dijkstra;

#[fastout]
fn main() {
    input! {
        n: usize,
        edges: [(Usize1, Usize1, usize); n-1],
        (q, k): (usize, Usize1),
    }
    let g = UnGraph::<usize, usize, usize>::from_edges(&edges);
    let res = dijkstra(&g, NodeIndex::new(k), None, |e| *e.weight());
    for _ in 0..q {
        input! {
            (x, y): (Usize1, Usize1),
        }
        println!("{}", res[&NodeIndex::new(x)] + res[&NodeIndex::new(y)]);
    }
}
