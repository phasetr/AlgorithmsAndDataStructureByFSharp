// https://atcoder.jp/contests/tessoku-book/submissions/36395190
use proconio::input;
use superslice::*;

fn main() {
    input! { n: usize, k: i32, a: [i32; n] }

    let mut ans = 0;
    for i in 0..n {
        let pick = a[i];
        let lb = a.lower_bound(&(pick - k));
        ans += i - lb;
    }

    println!("{}", ans);
}
