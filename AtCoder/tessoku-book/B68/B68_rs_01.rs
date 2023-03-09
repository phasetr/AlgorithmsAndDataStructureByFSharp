// https://atcoder.jp/contests/tessoku-book/submissions/38839103
use proconio::input;

fn dfs(
    pos: usize,
    goal: usize,
    f: i64,
    g: &mut [Vec<(usize, i64, usize)>],
    visited: &mut [bool],
) -> i64 {
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

fn main() {
    input! {
        n: usize,
        m: usize,
        p: [i64; n],
        ab: [(usize, usize); m],
    }

    let n = n + 2;
    let mut graph = vec![vec![]; n];

    let mut offset = 0i64;
    for (i, &p) in p.iter().enumerate() {
        let i = i + 1;
        let s = 0;
        let t = n - 1;
        let ns = graph[s].len();
        let nt = graph[t].len();
        graph[i].push((s, 0, ns));
        if p > 0 {
            offset += p;
            graph[s].push((i, p, 0));
            graph[i].push((t, 0, nt));
        } else {
            graph[s].push((i, 0, 0));
            graph[i].push((t, -p, nt));
        }
        graph[t].push((i, 0, 1));
    }

    const MAX: i64 = 1 << 20;
    for (a, b) in ab {
        let na = graph[a].len();
        let nb = graph[b].len();
        graph[a].push((b, MAX, nb));
        graph[b].push((a, 0, na));
    }

    let mut total = 0;
    loop {
        let mut visited = vec![false; n];
        let f = dfs(0, n - 1, 10000, &mut graph, &mut visited);
        if f == 0 {
            let result = offset - total;
            println!("{}", result);
            return;
        }
        total += f;
    }
}
