// https://atcoder.jp/contests/tessoku-book/submissions/36319859
fn main(){
    proconio::input!{n: usize, a: [usize; n - 1], b: [usize; n - 2]};
    let mut dp = vec![0; n];
    dp[1] = a[0];
    for i in 2 .. n {
        dp[i] = (dp[i - 1] + a[i - 1]).min(dp[i - 2] + b[i - 2]);
    }
    println!("{}", dp[n - 1]);
}
