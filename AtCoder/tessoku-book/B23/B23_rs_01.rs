// https://atcoder.jp/contests/tessoku-book/submissions/38652956
fn main() {
    proconio::input! {
        n: usize,
        p: [(f64, f64); n],
    };

    let mut dp = vec![vec![1e30; n]; 1<<n];
    dp[0][0] = 0.0;
    for i in 0..1<<n {
        for j in 0..n {
            if i >> j & 1 == 1 {
                continue;
            }
            dp[i | 1<<j][j] = dp[i].iter().enumerate().fold(1e30, |min, (k, s)| f64::min(min, s + dist(p[k], p[j]))); 
        }
    }

    let ans = dp[(1<<n) - 1].iter().enumerate().fold(1e30, |min, (k, s)| f64::min(min, s + dist(p[k], p[0])));
    println!("{}", ans);
}

fn dist(a: (f64, f64), b: (f64, f64)) -> f64 {
    return ((a.0 - b.0)*(a.0 - b.0) + (a.1 - b.1)*(a.1 - b.1)).powf(0.5);
}
