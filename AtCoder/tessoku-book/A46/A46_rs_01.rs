// https://atcoder.jp/contests/tessoku-book/submissions/35462733
use itertools::Itertools;
use proconio::input;

type P = (i64, i64);
const INF: f64 = 1e18;

fn dist_sq(a: P, b: P) -> i64 {
    (a.0 - b.0).pow(2) + (a.1 - b.1).pow(2)
}
fn dist(a: P, b: P) -> f64 {
    (dist_sq(a, b) as f64).sqrt()
}

fn main() {
    input! {
        n: usize,
        xy: [(i64, i64); n],
    }
    let mut p = 0;
    let mut rest = (1..n).collect_vec();
    let mut res = vec![0];
    for _ in 0..n - 1 {
        let mut mn = (INF, 0);
        for i in 0..rest.len() {
            let q = rest[i];
            let d = dist(xy[p], xy[q]);
            if mn.0 > d {
                mn = (d, i);
            }
        }
        let q = rest.swap_remove(mn.1);
        res.push(q);
        p = q;
    }
    res.push(0);
    println!("{}", res.iter().map(|x| (x + 1).to_string()).join("\n"));
}
