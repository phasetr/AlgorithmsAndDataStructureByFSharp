// https://atcoder.jp/contests/tessoku-book/submissions/36322699
use std::collections::BTreeSet;
use proconio::{input, fastout};

#[fastout]
fn main() {
    input!{q: usize}
    let mut b = BTreeSet::new();
    for _ in 0 .. q {
        input!{n: usize, m: i64}
        if n == 1 {
            b.insert(m);
        }
        else if n == 2 {
            if b.is_empty() {
                println!("-1");
            } else {
                let x = (b.range(.. m).rev().next().unwrap_or(&std::i64::MAX) - m).abs();
                let y = (b.range(m ..).next().unwrap_or(&std::i64::MAX) - m).abs();
                println!("{}", x.min(y));
            }
        }
    }
}
