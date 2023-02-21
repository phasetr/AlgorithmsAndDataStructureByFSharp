// https://atcoder.jp/contests/tessoku-book/submissions/36715805
use std::collections::BinaryHeap;
use proconio::{input, marker::Usize1};

fn main() {
    input!{n: usize, d: usize, j: [(Usize1, usize); n]}
    let mut c = vec![vec![]; d];
    j.into_iter().for_each(|(i, v)| c[i].push(v));
    let mut b = BinaryHeap::new();
    let mut r = 0;
    for w in c {
        b.extend(w);
        if let Some(v) = b.pop() {
            r += v;
        }
    }
    println!("{}", r);
}
