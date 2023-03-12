// https://atcoder.jp/contests/tessoku-book/submissions/38844616
use proconio::{input, marker::Usize1};

fn main() {
    input! {
        n: usize,
        m: usize,
        k: usize,
        ab: [(Usize1, Usize1); m],
    }

    let mut scores = vec![vec![0; n]; n];
    for (a, b) in ab {
        for i in 0..=a {
            for j in b..n {
                scores[i][j] += 1;
            }
        }
    }

    const MIN: i64 = -(1 << 20);
    let mut dp = vec![vec![MIN; n + 1]; k + 1];
    dp[0][0] = 0;
    for i in 0..k {
        for j in 0..n {
            for k in 0..=j {
                dp[i + 1][j + 1] = dp[i + 1][j + 1].max(dp[i][k] + scores[k][j]);
            }
        }
    }

    let result = dp[k][n];
    println!("{}", result);
}
