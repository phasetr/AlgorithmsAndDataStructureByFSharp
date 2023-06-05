use proconio::input;
use std::collections::HashMap;

fn solve(n:usize,av:Vec<usize>,bv:Vec<usize>) -> usize {
    let mut dp:Vec<usize> = vec![0;n];
    dp[1] = av[0];
    for i in 2..n {
        dp[i] = std::cmp::min(dp[i-1]+av[i-1],dp[i-2]+bv[i-2]);
    }
    dp[n-1]
}
#[proconio::fastout]
fn main() {
    input! {
        n: usize,
        av: [usize;n-1],
        bv: [usize;n-2]
    }
    println!("{}", solve(n,av,bv));
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn test1() {
        let (n,av,bv):(usize,Vec<usize>,Vec<usize>) = (5,vec![2,4,1,3],vec![5,3,7]);
        assert_eq!(solve(n,av,bv), 8);
        let (n,av,bv):(usize,Vec<usize>,Vec<usize>) = (10,vec![1,19,75,37,17,16,33,18,22],vec![41,28,89,74,98,43,42,31]);
        assert_eq!(solve(n,av,bv), 157);
    }
}
