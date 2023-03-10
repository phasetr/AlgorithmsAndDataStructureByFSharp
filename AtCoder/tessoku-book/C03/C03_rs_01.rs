// https://atcoder.jp/contests/tessoku-book/submissions/36138027
use std::cmp::Ordering::*;
use proconio::{fastout, input, marker::Usize1};

#[fastout]
fn main() {
    input!{d: usize, mut a: [i64; d], q: usize, x: [(Usize1, Usize1); q]}
    (1 .. d).for_each(|i| a[i] += a[i - 1]);
    for (s, t) in x {
        let r = match a[s].cmp(&a[t]) {
            Greater => format!("{}", s + 1),
            Equal => "Same".to_string(),
            Less => format!("{}", t + 1)
        };
        println!("{}", r);
    }
}
