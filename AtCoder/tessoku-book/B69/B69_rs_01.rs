// https://atcoder.jp/contests/tessoku-book/submissions/38841664
use proconio::{input, marker::Chars};

fn dfs(
    pos: usize,
    goal: usize,
    flow: usize,
    graph: &mut [Vec<(usize, usize, usize)>],
    visited: &mut [bool],
) -> usize {
    if pos == goal {
        return flow;
    }
    visited[pos] = true;

    for i in 0..graph[pos].len() {
        let (to, cap, j) = graph[pos][i];
        if cap == 0 || visited[to] {
            continue;
        }
        let flow = dfs(to, goal, flow.min(cap), graph, visited);
        if flow >= 1 {
            graph[pos][i].1 -= flow;
            graph[to][j].1 += flow;
            return flow;
        }
    }
    0
}

// a -- cap --> b
fn f(a: usize, b: usize, cap: usize, graph: &mut [Vec<(usize, usize, usize)>]) {
    let na = graph[a].len();
    let nb = graph[b].len();
    graph[a].push((b, cap, nb));
    graph[b].push((a, 0, na));
}

fn main() {
    input! {
        n: usize,
        m: usize,
        c: [Chars; n],
    }

    let num_node = 1 + n + 24 + 1;
    let mut graph = vec![vec![]; num_node]; // (node, capacity, rev_edge)

    for i in 0..n {
        f(0, i + 1, 10, &mut graph);
        for j in 0..24 {
            if c[i][j] == '1' {
                f(i + 1, 1 + n + j, 1, &mut graph);
            }
        }
    }
    for i in 0..24 {
        f(1 + n + i, num_node - 1, m, &mut graph);
    }

    let mut total = 0;
    loop {
        let mut visited = vec![false; num_node];
        let f = dfs(0, num_node - 1, m * 24, &mut graph, &mut visited);
        if f == 0 {
            let yes = total == m * 24;
            println!("{}", if yes { "Yes" } else { "No" });
            return;
        }
        total += f;
    }
}
