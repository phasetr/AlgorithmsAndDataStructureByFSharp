// https://atcoder.jp/contests/tessoku-book/submissions/37364611
use proconio::input;
use proconio::marker::Usize1;

#[allow(non_snake_case)]
fn main() {
    input! {
        N: usize,
        PA: [(Usize1, usize); N]
    }
    let mut dp = vec![vec![0; N]; N];
    // 残り1個のとき得られる得点は0なため、i = N - 1, i = jのときは初期値0のままとする
    for i in (0..(N - 1)).rev() {
        for j in (i + 1)..N {
            let a = if PA[i].0 > i && PA[i].0 <= j { PA[i].1 } else { 0 };
            let b = if PA[j].0 >= i && PA[j].0 < j { PA[j].1 } else { 0 };
            dp[i][j] = std::cmp::max(dp[i + 1][j] + a, dp[i][j - 1] + b);
        }
    }
    println!("{}", dp[0][N - 1]);
}
