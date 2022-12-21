// https://atcoder.jp/contests/abc146/submissions/22926141
use proconio::{fastout, input};

#[fastout]
fn main() {
    input! {
        n: usize,
        ab: [(usize, usize); n - 1],
    }
    let mut graph = vec![Vec::new(); n];
    for &(a, b) in &ab {
        graph[a - 1].push(b - 1);
    }
    let mut colors = vec![0; n];
    for i in 0..n - 1 {
        let mut c = 1;
        for &j in &graph[i] {
            c += if c == colors[i] { 1 } else { 0 };
            colors[j] = c;
            c += 1;
        }
    }
    println!("{}", colors.iter().max().unwrap());
    for &(_, b) in &ab {
        println!("{}", colors[b - 1]);
    }
}
