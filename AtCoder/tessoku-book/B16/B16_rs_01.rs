// https://atcoder.jp/contests/tessoku-book/submissions/38349999
use proconio::input;

fn main() {
    input! {
        n: usize,
        h: [i32; n],
    }
    let mut dp = vec![0; n+1];
    dp[1] = 0;
    dp[2] = (h[1] - h[0]).abs();
    for i in 3..=n {
        dp[i] = ((h[i-1] - h[i-3]).abs() + dp[i-2]).min((h[i-1] - h[i-2]).abs() + dp[i-1]);
    }
    println!("{}", dp[n]);
}
