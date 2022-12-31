// https://atcoder.jp/contests/tessoku-book/submissions/35368874
use proconio::input;
fn main() {
    input! {
        n: usize,
        W: usize,
        wv: [(usize, i64); n],
    }
    let mut dp = vec![0; W + 1];
    for &(w, v) in &wv {
        for i in (0..=W - w).rev() {
            dp[i + w] = dp[i + w].max(dp[i] + v);
        }
    }
    println!("{}", dp[W]);
}
