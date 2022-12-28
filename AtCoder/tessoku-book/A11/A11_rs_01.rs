// https://atcoder.jp/contests/tessoku-book/submissions/35180079
use proconio::input;
fn main() {
    input! {
        n: usize,
        x: i64,
        a: [i64; n],
    }

    let mut l = 0;
    let mut r = n;
    while r - l > 1 {
        let c = (l + r) / 2;
        if a[c] <= x {
            l = c;
        } else {
            r = c;
        }
    }

    println!("{}", l + 1);
}
