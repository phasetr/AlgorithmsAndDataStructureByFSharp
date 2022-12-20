// https://atcoder.jp/contests/abc126/submissions/27465683
use proconio::{input, fastout, marker::Usize1};

#[fastout]
fn main() {
    input!{
        n: usize,
        uvw: [(Usize1, Usize1, i64); n-1]
    }
    let mut to = vec![vec![]; n];
    for (u, v, w) in uvw {
        to[u].push((v,w));
        to[v].push((u,w));
    }
    let mut dist = vec![-1; n];
    dist[0] = 0;

    let mut q = Vec::new();
    q.push(0);
    while let Some(x) = q.pop() {
        for &(y, w) in &to[x] {
            if dist[y] >= 0 { continue; }
            dist[y] = dist[x] + w;
            q.push(y);
        }
    }
    for i in 0..n {
        println!("{}", dist[i] & 1);
    }
}
