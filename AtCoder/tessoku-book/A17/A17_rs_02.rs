// https://atcoder.jp/contests/tessoku-book/submissions/37888105
use itertools::Itertools;
use proconio::input;
#[proconio::fastout]
fn main() {
    input! {
        n: usize,
        a: [usize; n - 1],
        b: [usize; n - 2],
    }

    let mut dp = vec![0; n];
    dp[1] = a[0];
    for i in 0..(n - 2) {
        dp[i + 2] = (dp[i] + b[i]).min(dp[i + 1] + a[i + 1]);
    }

    let mut v = vec![n - 1];
    loop {
        let mut i = *v.last().unwrap();
        if i == 0 {
            break;
        }

        if dp[i - 1] + a[i - 1] == dp[i] {
            i -= 1;
        } else {
            i -= 2;
        }
        v.push(i);
    }

    let result = v.iter().rev().map(|&x| x + 1).join(" ");
    println!("{}", v.len());
    println!("{}", result);
}
