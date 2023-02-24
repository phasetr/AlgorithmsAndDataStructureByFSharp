// https://atcoder.jp/contests/tessoku-book/submissions/36312735
use proconio::{input, fastout, marker::Usize1};

#[fastout]
fn main() {
    input!{n: usize, m: usize, a: [Usize1; m]}
    let mut c = vec![0; n];
    a.iter().for_each(|&v| c[v] += 1);
    for v in c {
        println!("{}", m - v);
    }
}
