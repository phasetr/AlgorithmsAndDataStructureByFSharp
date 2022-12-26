// https://atcoder.jp/contests/tessoku-book/submissions/35014354
use proconio::input;
fn main() {
    input! {
        n: i64,
        k: i64,
    }
    println!("{}", (1..=n).map(|i| (1..=n).filter(|j| 1<=k-(i+j) && k-(i+j)<=n).count()).sum::<usize>());
}
