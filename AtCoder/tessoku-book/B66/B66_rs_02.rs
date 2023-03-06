// https://atcoder.jp/contests/tessoku-book/submissions/38832682
use std::collections::HashSet;

use petgraph::unionfind::UnionFind;
use proconio::{input, marker::Usize1};

#[proconio::fastout]
fn main() {
    input! {
        n: usize,
        m: usize,
        ab: [(Usize1, Usize1); m],
        q: usize,
    }

    let mut set = HashSet::new();
    let mut qs = Vec::with_capacity(n);
    for _ in 0..q {
        input! {
            t: usize,
        }
        if t == 1 {
            input! {
                x: Usize1,
            }
            qs.push((t, ab[x].0, ab[x].1));
            set.insert(x);
        } else {
            input! {
                u: Usize1,
                v: Usize1,
            }
            qs.push((t, u, v));
        }
    }

    let mut uf = UnionFind::new(n);
    for (i, &(a, b)) in ab.iter().enumerate() {
        if !set.contains(&i) {
            uf.union(a, b);
        }
    }

    let mut results = Vec::with_capacity(q - set.len());
    for &(t, u, v) in qs.iter().rev() {
        if t == 1 {
            uf.union(u, v);
        } else {
            results.push(uf.equiv(u, v));
        }
    }

    for &yes in results.iter().rev() {
        println!("{}", if yes { "Yes" } else { "No" });
    }
}
