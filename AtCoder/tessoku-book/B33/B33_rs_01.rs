// https://atcoder.jp/contests/tessoku-book/submissions/37366579
use proconio::input;
fn main() {
    input! {
        n: usize,
        h: usize,
        w: usize,
        ab: [(i64, i64); n],
    }

    println!("{}", if (0..n).fold(0, |acc, i| acc ^ ((ab[i].0 - 1) ^ (ab[i].1 - 1))) != 0 {"First"} else {"Second"});
}
