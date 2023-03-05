// https://atcoder.jp/contests/tessoku-book/submissions/38832384
use itertools::Itertools;
use proconio::{input, marker::Usize1};

fn f(cur: usize, prev: usize, graph: &[Vec<usize>], v: &mut [usize]) -> usize {
    let mut lv = 0;
    for &next in &graph[cur] {
        if next != prev {
            lv = lv.max(f(next, cur, graph, v) + 1);
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

    let mut graph = vec![vec![]; n];
    for &(a, b) in &ab {
        graph[a].push(b);
        graph[b].push(a);
    }

    let mut v = vec![0; n];
    f(t, t, &graph, &mut v);

    let result = v.iter().join(" ");
    println!("{}", result);
}
