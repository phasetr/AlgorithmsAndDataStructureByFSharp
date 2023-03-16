// https://atcoder.jp/contests/tessoku-book/submissions/36141999
#![allow(non_snake_case)]
use std::{
    cmp::Reverse,
    collections::{BinaryHeap, VecDeque},
};

use proconio::{input, marker::Usize1};

fn main() {
    input! {
        N: usize,
        M: usize,
    }
    let mut G = vec![vec![]; N];
    for _ in 0..M {
        input! {
            A: Usize1,
            B: Usize1,
            C: usize
        }
        G[A].push((B, C));
        G[B].push((A, C));
    }

    let INF = 1usize << 60;
    let mut dists = vec![INF; N];
    let mut heap = BinaryHeap::new();
    heap.push(Reverse((0, 0)));

    while let Some(Reverse((d, v))) = heap.pop() {
        if d >= dists[v] {
            continue;
        }
        dists[v] = d;
        for &(u, w) in G[v].iter() {
            let nd = d + w;
            if dists[u] <= nd {
                continue;
            }
            heap.push(Reverse((nd, u)));
        }
    }

    let mut seen = vec![false; N];
    let mut queue = VecDeque::new();
    queue.push_back(N - 1);
    while let Some(v) = queue.pop_front() {
        if seen[v] {
            continue;
        }
        seen[v] = true;
        for &(u, w) in G[v].iter() {
            if dists[u] + w == dists[v] {
                queue.push_back(u);
            }
        }
    }
    let ans = seen.iter().filter(|&x| *x).count();
    println!("{}", ans);
}
