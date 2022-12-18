// https://atcoder.jp/contests/abc157/submissions/32875410
use itertools::Itertools;
use petgraph::unionfind::UnionFind;
use proconio::{input, marker::Usize1};

fn main() {
    input! {
        n:usize,
        m:usize,
        k:usize,
        ab:[(Usize1,Usize1);m],
        cd:[(Usize1,Usize1);k],
    }
    let mut ans = vec![0; n];
    let mut uf = UnionFind::new(n);
    for &(a, b) in &ab {
        uf.union(a, b);
    }
    let mut count = vec![0; n];
    for i in 0..n {
        count[uf.find(i)] += 1;
    }
    for i in 0..n {
        ans[i] = count[uf.find(i)] - 1;
    }
    for (a, b) in ab {
        ans[a] -= 1;
        ans[b] -= 1;
    }
    for (c, d) in cd {
        if uf.find(c) == uf.find(d) {
            ans[c] -= 1;
            ans[d] -= 1;
        }
    }
    println!("{}", ans.iter().join(" "));
}
