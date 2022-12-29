// https://atcoder.jp/contests/tessoku-book/submissions/35368432
use proconio::input;
fn main() {
    input! {
        n: usize,
        k: i64,
        a: [i64; n],
    }
    let mut res = 0;
    let mut r = 0;
    for l in 0..n {
        while r < n && a[r] - a[l] <= k {
            r += 1;
        }
        res += r - l - 1;
    }
    println!("{}", res);
}
