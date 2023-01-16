// https://atcoder.jp/contests/tessoku-book/submissions/37625054
use proconio::{input, fastout};
// use whiteread::Reader;
use std::collections::HashMap;

#[fastout]
fn main() {
    input! {
        n: usize, q: usize,
        aa: [usize; n],
        xys: [(usize, usize); q]
    }

    let mut dp = vec![vec![0; n+1]; 32];

    for i in 1..= n {
        dp[0][i] = aa[i-1];
    }

    for i in 1..32 {
        for j in 1..=n {
            dp[i][j] = dp[i-1][dp[i-1][j]];
        }
    }

    for (x, y) in xys {
        let mut p = x;
        for i in 0..32 {
            if y & (1<<i) > 0 {
                p = dp[i][p];
            }
        }

        println!("{}", p);
    }
}
