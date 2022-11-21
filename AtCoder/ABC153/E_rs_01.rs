// https://atcoder.jp/contests/abc153/submissions/35859169
use proconio::input;

fn main() {
    input! { h: usize, n: usize, ab: [(usize, usize); n] }

    let mut dp = vec![std::usize::MAX; h + 1];
    dp[0] = 0;
    for i in 1..=h {
        for j in 0..n {
            let (a, b) = ab[j];
            dp[i] = dp[i].min(if i > a { dp[i - a] } else { 0 } + b);
        }
    }
    let ans = dp[h];

    println!("{}", ans);
}
