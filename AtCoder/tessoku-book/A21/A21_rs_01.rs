// https://atcoder.jp/contests/tessoku-book/submissions/35460215
use proconio::input;
fn main() {
    input! {
        n: usize,
        pa: [(usize, i64); n],
    }

    let mut dp = vec![vec![0; n]; n];
    for l in 0..n {
        for r in (l + 1..n).rev() {
            dp[l + 1][r] = dp[l + 1][r].max(dp[l][r] + if l < pa[l].0 - 1 && pa[l].0 - 1 <= r {pa[l].1} else {0});
            dp[l][r - 1] = dp[l][r - 1].max(dp[l][r] + if l <= pa[r].0 - 1 && pa[r].0 - 1 < r {pa[r].1} else {0});
        }
    }

    println!("{}", (0..n).fold(0i64, |v, i| v.max(*dp[i].iter().max().unwrap())));
}
