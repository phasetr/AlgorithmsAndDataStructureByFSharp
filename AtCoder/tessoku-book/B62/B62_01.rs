// https://atcoder.jp/contests/tessoku-book/submissions/38453719
use std::collections::BinaryHeap;

use itertools::Itertools;
use proconio::{input, marker::Usize1};

fn main() {
    input! {
        n: usize,
        m: usize,
        ab: [(Usize1, Usize1); m],
    }

    let mut g = vec![vec![]; n];
    for (a, b) in ab {
        g[a].push(b);
        g[b].push(a);
    }
    let g = g;

    let mut heap = BinaryHeap::new();
    heap.push(0);

    let mut prev = vec![n; n]; // n: unused
    while let Some(i) = heap.pop() {
        for &j in &g[i] {
            if j != 0 && prev[j] == n {
                prev[j] = i;
                heap.push(j);
            }
        }
    }

    let mut v = vec![];
    let mut i = n - 1;
    while i > 0 {
        v.push(i + 1);
        i = prev[i];
    }
    v.push(1);
    let result = v.iter().rev().join(" ");
    println!("{}", result);
}
