// https://atcoder.jp/contests/tessoku-book/submissions/38832384
use itertools::Itertools;
use proconio::{input, marker::Usize1};

fn dfs(cur: usize, prev: usize, g: &[Vec<usize>], v: &mut [usize]) -> usize {
    let mut lv = 0;
    for &next in &g[cur] {
        if next != prev {
            lv = lv.max(dfs(next, cur, g, v) + 1);
        }
    }
    v[cur] = lv;
    lv
}

fn main() {
    input! {
        n: usize,
        t: Usize1,
        ab: [(Usize1, Usize1); n - 1],
    }

    let mut g = vec![vec![]; n];
    for &(a, b) in &ab {
        g[a].push(b);
        g[b].push(a);
    }

    let mut v = vec![0; n];
    dfs(t, t, &g, &mut v);

    println!("{}", v.iter().join(" "));
}
