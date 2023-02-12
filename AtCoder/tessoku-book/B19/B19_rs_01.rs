// https://atcoder.jp/contests/tessoku-book/submissions/36273128
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
    let mut max_v = 0;
    for (w, v) in wvs {
        for vn in (v..=max_v + v).rev() {
            let sum_v = dp[vn - v] + w;
            if sum_v < dp[vn] {
                dp[vn] = sum_v;
            }
        }
        max_v += v;
    }
    let mut ans = 100_000;
    while dp[ans] > W {
        ans -= 1;
    }
    println!("{}", ans);
}
