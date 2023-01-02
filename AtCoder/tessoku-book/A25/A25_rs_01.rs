// https://atcoder.jp/contests/tessoku-book/submissions/35267473
use proconio::input;
use proconio::marker::Chars;
#[proconio::fastout]
fn main() {
    input!{
        h:usize,w:usize,
        chw:[Chars;h],
    }
    let mut dp = vec![vec![0_usize;w+1];h+1];
    dp[0][1] = 1;
    for i in 1..=h{
        for j in 1..=w{
            if chw[i-1][j-1] != '#'{
                dp[i][j] = dp[i-1][j] + dp[i][j-1];
            }
        }
    }
    println!("{}",dp[h][w]);
}
