// https://atcoder.jp/contests/tessoku-book/submissions/39201921
use std::{cmp::Reverse, collections::BinaryHeap};

use proconio::{input, marker::Usize1};

fn main() {
    input! {
        n: usize,
        m: usize,
        k: usize,
        asbt: [(Usize1, usize, Usize1, usize); m],
    }
    let mut heap = BinaryHeap::new();
    for (a, s, b, t) in asbt {
        heap.push((Reverse(s), 0, a, b, t));
    }
    let mut v = vec![0; n];
    while let Some((_, i, a, b, t)) = heap.pop() {
        if i == 0 {
            heap.push((Reverse(t + k), 1, b, v[a] + 1, 0));
        } else {
            v[a] = v[a].max(b);
        }
    }
    let result = v.iter().max().unwrap_or(&0);
    println!("{}", result);
}
