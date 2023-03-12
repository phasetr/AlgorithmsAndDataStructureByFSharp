// https://atcoder.jp/contests/tessoku-book/submissions/37425155
use proconio::input;

fn main() {
    input! {
        n: usize,
        a: [usize; n],
    };
    let mut dp = (0, 0);
    for a_i in a {
        let (p2, p1) = dp;
        dp = (p2.max(p1), p2 + a_i);
    }
    let ans = dp.0.max(dp.1);
    println!("{}", ans);
}
