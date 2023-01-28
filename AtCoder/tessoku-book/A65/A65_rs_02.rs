// https://atcoder.jp/contests/tessoku-book/submissions/37636010
use itertools::Itertools;
use proconio::{input, marker::Usize1};
#[proconio::fastout]
fn main() {
    input! {
        n:usize,
        an:[Usize1;n-1],
    }
    let mut v = vec![0; n];
    for i in (1..n).rev() {
        v[an[i - 1]] += 1 + v[i];
    }
    println!("{}", v.iter().join(" "));
}
