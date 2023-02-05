// https://atcoder.jp/contests/tessoku-book/submissions/37095445
fn main() {
    proconio::input!{n: usize, mut e: [(usize, usize); n]}
    e.sort_by(|a, b| a.1.cmp(&b.1));
    let mut dp = vec![0; e.iter().max_by(|&a, &b| a.1.cmp(&b.1)).unwrap().1 + 1];
    for (et, ed) in e.iter().filter(|&&(a, b)| a <= b) {
        for i in (0 ..= ed - et).rev() {
            dp[i + et] = dp[i + et].max(dp[i] + 1);
        }
    }
    println!("{}", dp.iter().max().unwrap());
}
