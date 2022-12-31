// https://atcoder.jp/contests/tessoku-book/submissions/36927042
use proconio::{input, marker::Bytes};

fn main(){
    input!{s: Bytes, t: Bytes}
    let mut dp = vec![vec![0u16; s.len() + 1]; t.len() + 1];
    for i in 0 .. t.len(){
        for j in 0 .. s.len(){
            match t[i] == s[j]{
                true => dp[i + 1][j + 1] = dp[i][j] + 1,
                false => dp[i + 1][j + 1] = dp[i][j + 1].max(dp[i + 1][j])
            }
        }
    }
    println!("{}", dp[t.len()][s.len()]);
}
