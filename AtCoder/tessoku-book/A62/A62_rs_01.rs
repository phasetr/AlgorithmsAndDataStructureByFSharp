// https://atcoder.jp/contests/tessoku-book/submissions/37999371
use petgraph::unionfind::UnionFind;
use proconio::{fastout, input, marker::Usize1};

#[fastout]
fn main() {
    input! {
        n: usize,
        ab: [(Usize1, Usize1)],
    }

    let mut uf = UnionFind::new(n);
    for &(a, b) in &ab {
        uf.union(a, b);
    }
    let yes = (0..n).all(|i| uf.equiv(i, 0));
    println!(
        "{}",
        if yes {
            "The graph is connected."
        } else {
            "The graph is not connected."
        }
    );
}
