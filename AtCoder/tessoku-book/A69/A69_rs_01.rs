// https://atcoder.jp/contests/tessoku-book/submissions/35028436
// #![allow(unused_imports)]
use proconio::{
    fastout, input,
    marker::{Bytes, Chars, Isize1, Usize1},
    source::line::LineSource,
};
use std::cmp::{max, min, Ordering, Reverse};
use std::collections::*;
use std::{f64, i128, i32, i64, u128, u32, u64};
use superslice::*;

#[fastout]
fn main() {
    input! {
        n: usize,
        c: [Chars;n],
    }
    let mut graph = vec![vec![]; n * 2];
    for i in 0..n {
        for j in 0..n {
            if c[i][j] == '.' {
                continue;
            }
            graph[i].push(n + j);
        }
    }
    println!("{}", bipartite_matching(&graph));
}

#[allow(dead_code)]
pub fn bipartite_matching(g: &[Vec<usize>]) -> usize {
    fn dfs(v: usize, g: &[Vec<usize>], mat: &mut [Option<usize>], used: &mut [bool]) -> bool {
        used[v] = true;
        for &u in &g[v] {
            if mat[u].is_none() || !used[mat[u].unwrap()] && dfs(mat[u].unwrap(), g, mat, used) {
                mat[v] = Some(u);
                mat[u] = Some(v);
                return true;
            }
        }
        false
    }
    let mut res = 0;
    let mut mat = vec![None; g.len()];
    for v in 0..g.len() {
        if mat[v].is_none() {
            let mut used = vec![false; g.len()];
            if dfs(v, g, &mut mat, &mut used) {
                res += 1;
            }
        }
    }
    res
}
