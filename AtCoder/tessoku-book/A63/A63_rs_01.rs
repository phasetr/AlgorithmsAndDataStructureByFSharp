// https://atcoder.jp/contests/tessoku-book/submissions/36774489
use proconio::{input, fastout};
use proconio::marker::{Bytes, Chars, Usize1};
use itertools::Itertools;
use std::collections::VecDeque;

#[fastout]
fn main() {
    input!{
        n: usize,
        m: usize,
        p: [(Usize1, Usize1); m],
    }
    let mut graph = vec![vec![]; n];
    for &(a, b) in p.iter() {
        graph[a].push(b);
        graph[b].push(a);
    }

    let mut que = VecDeque::new();
    let mut dist = vec![-1; n];
    que.push_back(0);
    dist[0] = 0;

    while let Some(v) = que.pop_front() {
        for &nv in graph[v].iter() {
            if dist[nv] != -1 { continue; }

            dist[nv] = dist[v] + 1;
            que.push_back(nv);
        }
    }

    for e in dist {
        println!("{}", e);
    }
}
