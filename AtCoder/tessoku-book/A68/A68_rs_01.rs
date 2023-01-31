// https://atcoder.jp/contests/tessoku-book/submissions/38001747
use proconio::{input, marker::Usize1};

fn dfs(
    pos: usize,
    goal: usize,
    f: usize,
    g: &mut [Vec<(usize, usize, usize)>],
    visited: &mut [bool],
) -> usize {
    if pos == goal {
        return f;
    }
    visited[pos] = true;

    for i in 0..g[pos].len() {
        let (to, cap, j) = g[pos][i];
        if cap == 0 || visited[to] {
            continue;
        }
        let flow = dfs(to, goal, f.min(cap), g, visited);
        if flow >= 1 {
            g[pos][i].1 -= flow;
            g[to][j].1 += flow;
            return flow;
        }
    }
    0
}

#[proconio::fastout]
fn main() {
    input! {
        n: usize,
        abc: [(Usize1, Usize1, usize)],
    }

    let mut g = vec![vec![]; n]; // (node, capacity, rev_edge)
    for &(a, b, c) in &abc {
        let na = g[a].len();
        let nb = g[b].len();
        g[a].push((b, c, nb));
        g[b].push((a, 0, na));
    }

    let mut total = 0;
    loop {
        let mut visited = vec![false; n];
        let f = dfs(0, n - 1, 10000, &mut g, &mut visited);
        if f == 0 {
            println!("{}", total);
            return;
        }
        total += f;
    }
}
