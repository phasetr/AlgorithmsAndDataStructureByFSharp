// https://atcoder.jp/contests/abc099/submissions/27970141
use proconio::{input, fastout};

#[fastout]
fn main() {
    input!{
        n: usize,
    }

    let ans = (0..=n).map(|x| f(x, 6) + f(n-x, 9)).min().unwrap();
    println!("{}", ans);
}

use itertools::unfold;
fn f(x: usize, d: usize) -> usize {
    unfold(x, |x| { if *x > 0 { let ret = *x % d; *x /= d; Some(ret) } else { None }})
    .sum()
}
