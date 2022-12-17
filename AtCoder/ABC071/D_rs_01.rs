// https://atcoder.jp/contests/abc071/submissions/16945734
use proconio::marker::Bytes;
fn main() {
    proconio::input! {
        n: usize,
        s1: Bytes,
        s2: Bytes,
    }
    let mut t = 1u64;
    let mut p = 0;
    let mut i = 0;
    while i < n {
        let c = if s1[i] == s2[i] { 1 } else { 2 };
        t *= [[3, 2, 1], [6, 2, 3]][c - 1][p];
        i += c;
        p = c;
    }
    println!("{}", t % 1000000007);
}
