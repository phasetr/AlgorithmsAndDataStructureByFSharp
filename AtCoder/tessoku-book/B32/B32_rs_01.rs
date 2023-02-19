// https://atcoder.jp/contests/tessoku-book/submissions/35403945
use proconio::input;

fn main() {
    input! {
        n: usize,
        k: usize,
        a: [usize; k],
    }
    let mut dp = vec![false; n + 1];
    for i in 0..n {
        if dp[i] {
            continue;
        }
        for &x in &a {
            if i + x <= n {
                dp[i + x] = true;
            }
        }
    }
    println!("{}", if dp[n] { "First" } else { "Second" });
}
