// https://atcoder.jp/contests/tessoku-book/submissions/36462343
use proconio::input;
use superslice::Ext;

fn main() {
    input! { n: usize, a: [usize; n] }

    let mut dp = vec![1 << 30; n];
    for i in 0..n {
        let lb = dp.lower_bound(&a[i]);
        dp[lb] = a[i];
    }

    let ans = dp.lower_bound(&(1 << 30));
    println!("{}", ans);
}
