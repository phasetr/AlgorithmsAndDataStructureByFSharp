// https://atcoder.jp/contests/tessoku-book/submissions/36779630
#![allow(non_snake_case)]
use proconio::{input, marker};

#[proconio::fastout]
fn main() {
    input! {
        S: marker::Bytes,
        T: marker::Bytes,
    }
    let Slen = S.len();
    let Tlen = T.len();
    let mut dp: Vec<usize> = (0..=Slen).collect();
    for i in 0..Tlen {
        let mut cur = vec![0; Slen+1];
        let t = T[i];
        cur[0] = i+1;
        for j in 0..Slen {
            let s = S[j];
            let rep = if s == t { dp[j] } else { dp[j]+1 };
            let add = dp[j+1]+1;
            let del = cur[j]+1;
            cur[j+1] = rep.min(add).min(del);
        }
        dp = cur;
    }
    let ans = dp[Slen];
    println!("{}", ans);
}
