// https://atcoder.jp/contests/tessoku-book/submissions/36272934
#![allow(non_snake_case)]
use proconio::input;

#[proconio::fastout]
fn main() {
    input! {
        N: usize,
        W: usize,
        wvs: [(usize, usize); N],
    }
    let mut dp = vec![W + 1; 100_001];
    dp[0] = 0;
    for (w, v) in wvs {
        for vn in (v..=100_000).rev() {
            dp[vn] = dp[vn].min(dp[vn - v] + w);
        }
    }
    let mut ans = 100_000;
    while dp[ans] > W {
        ans -= 1;
    }
    println!("{}", ans);
}
