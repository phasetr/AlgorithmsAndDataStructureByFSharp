// https://atcoder.jp/contests/tessoku-book/submissions/36154307
fn main() {
    proconio::input!{n: usize, m: isize, a: [[usize; n]; m]}
    let mut c = a.iter().map(|v| {
        v.iter().enumerate().map(|(i, &b)| b << i).sum::<usize>()
    }).collect::<Vec<usize>>();
    c.sort();
    let mut dp = vec![m + 1; 1 << n];
    dp[0] = 0;
    for v in c {
        for i in 0 .. 1 << n {
            dp[i | v] = dp[i | v].min(dp[i] + 1);
        }
    }
    let r = dp.last().filter(|&&x| x != m + 1).unwrap_or(&-1);
    println!("{}", r);
}
