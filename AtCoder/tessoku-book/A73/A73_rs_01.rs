// https://atcoder.jp/contests/tessoku-book/submissions/36928412
use std::{collections::BinaryHeap, cmp::Reverse};
use proconio::{input, marker::Usize1};

fn main() {
    input!{n: usize, m: usize}
    let mut g = vec![vec![]; n];
    for _ in 0 .. m {
        input!{a: Usize1, b: Usize1, c: isize, d: isize}
        g[a].push((c, -d, b));
        g[b].push((c, -d, a));
    }
    let mut b = BinaryHeap::from(vec![Reverse((0, 0, 0))]);
    let mut d = vec![None; n];
    while let Some(Reverse((l, t, i))) = b.pop() {
        if d[i].is_none() {
            d[i] = Some((l, -t));
            b.extend(g[i].iter().filter(|&&v| d[v.2].is_none()).map(|&v| Reverse((v.0 + l, v.1 + t, v.2))));
        }
    }
    let (a, b) = d[n - 1].unwrap();
    println!("{} {}", a, b);
}
