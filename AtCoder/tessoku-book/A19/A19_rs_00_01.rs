// https://atcoder.jp/contests/tessoku-book/submissions/35368874
use proconio::input;
use std::cmp::max;

fn solve(n:usize,w:usize,wv:Vec<(usize,i64)>) -> i64 {
    let mut dp:Vec<i64> = vec![0;w+1];
    for (wi,vi) in wv {
        for i in (0..=w-wi).rev() {
            dp[i+wi] = max(dp[i+wi], dp[i]+vi);
        }
    }
    dp[w]
}
fn main() {
    input! {
        n: usize,
        W: usize,
        wv: [(usize, i64); n],
    }
    let mut dp = vec![0; W + 1];
    for &(w, v) in &wv {
        for i in (0..=W - w).rev() {
            dp[i + w] = dp[i + w].max(dp[i] + v);
        }
    }
    println!("{}", dp[W]);
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn test1() {
        let (n,w,wv):(usize,usize,Vec<(usize,i64)>) = (4,7,vec![(3,13),(3,17),(5,29),(1,10)]);
        assert_eq!(solve(n,w,wv), 40);
        let (n,w,wv):(usize,usize,Vec<(usize,i64)>) = (4,100,vec![(25,47),(25,53),(25,62),(25,88)]);
        assert_eq!(solve(n,w,wv), 250);
        let (n,w,wv):(usize,usize,Vec<(usize,i64)>) = (10,285,vec![(29,8000),(43,11000),(47,10000),(51,13000),(52,16000),(66,14000),(72,25000),(79,18000),(82,23000),(86,27000)]);
        assert_eq!(solve(n,w,wv), 87000);
    }
}
