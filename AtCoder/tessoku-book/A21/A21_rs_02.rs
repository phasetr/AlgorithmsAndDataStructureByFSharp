// https://atcoder.jp/contests/tessoku-book/submissions/35384337
use proconio::{input, marker::Usize1};

fn main() {
    input! {
        n: usize,
        pa: [(Usize1, i64); n],
    }
    let mut dp = vec![vec![0; n + 1]; n + 1];
    for w in (1..=n).rev() {
        for l in 0..=n - w {
            let r = l + w;
            let (p, a) = pa[l];
            dp[l + 1][r] = dp[l + 1][r].max(dp[l][r] + if l <= p && p < r { a } else { 0 });
            let (p, a) = pa[r - 1];
            dp[l][r - 1] = dp[l][r - 1].max(dp[l][r] + if l <= p && p < r { a } else { 0 });
        }
    }
    let mut res = 0;
    for i in 0..=n {
        res = res.max(dp[i][i]);
    }
    println!("{}", res);
}
