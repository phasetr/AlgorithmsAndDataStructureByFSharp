// https://atcoder.jp/contests/tessoku-book/submissions/37462786
use std::cmp::max;

fn main() {
    proconio::input! {
        n: usize,
        s: String
    };

    let cs: Vec<char> = s.chars().collect();
    let mut dp = vec![vec![0; n + 2]; n + 2];
    let mut answer = 0;
    for i in 0..n {
        for j in (i..n).rev() {
            let mut v = 0;
            v = max(v, dp[i][j+1]);
            v = max(v, dp[i+1][j+2]);
            if cs[i] == cs[j] {
                v = max(v, dp[i][j+2] + (if i != j { 2 } else { 1 }));
            }
            dp[i+1][j+1] = v;
            answer = max(answer, v);
        }
    }
    println!("{}", answer);
}
