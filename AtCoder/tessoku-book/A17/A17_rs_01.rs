// https://atcoder.jp/contests/tessoku-book/submissions/36694419
fn main(){
    proconio::input!{n: usize, a: [usize; n - 1], b: [usize; n - 2]};
    let mut dp = vec![0; n];
    dp[1] = a[0];
    for i in 2 .. n {
        dp[i] = (dp[i - 1] + a[i - 1]).min(dp[i - 2] + b[i - 2]);
    }
    let mut p = n - 1;
    let mut r = vec![p + 1];
    while p > 0 {
        if dp[p] - a[p - 1] == dp[p - 1] { r.push(p); p -= 1; }
        else { r.push(p - 1); p -= 2; }
    }
    println!("{}", r.len());
    println!("{}", r.iter().rev().map(|v| format!("{} ", v)).collect::<String>().trim_end());
}
