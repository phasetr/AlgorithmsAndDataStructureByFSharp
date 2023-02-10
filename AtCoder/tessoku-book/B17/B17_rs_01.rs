// https://atcoder.jp/contests/tessoku-book/submissions/37894641
use proconio::{input, fastout};
use std::cmp::min;

#[fastout]
fn main() {
    input! {
        n: usize,
        hs: [isize; n]
    }

    let mut dp = vec![(0isize, 0); n+1];
    dp[2] = ((hs[0] - hs[1]).abs(), 1);

    for i in 3..=n {
        dp[i] = min((dp[i-2].0 + (hs[i-1] - hs[i-3]).abs(), i-2),
                    (dp[i-1].0 + (hs[i-1] - hs[i-2]).abs(), i-1));
    }

    let mut v = Vec::new();
    v.push(n);

    while *v.last().unwrap() != 1 {
        let p = *v.last().unwrap();
        let (_, np) = dp[p];
        v.push(np);
    }

    println!("{}", v.len());
    while !v.is_empty() {
        print!("{} ", v.pop().unwrap());
    }

    println!("");
}
