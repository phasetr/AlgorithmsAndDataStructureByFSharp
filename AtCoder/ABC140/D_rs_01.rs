// https://atcoder.jp/contests/abc140/submissions/26852270
use proconio::marker::*;
use proconio::*;
fn main() {
    input! {n: usize,k: usize,s: Bytes}
    println!("{}",(n - 1).min((0..n - 1).filter(|&i| s[i] == s[i + 1]).count() + 2 * k));
}
