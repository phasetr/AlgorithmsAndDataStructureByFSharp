// https://atcoder.jp/contests/tessoku-book/submissions/35460900
use proconio::input;

fn main() {
    input! {
        n: usize,
        x: usize,
        y: usize,
        a: [usize; n],
    }
    let mut s = 0;
    for i in 0..n {
        s ^= a[i] % 5 / 2;
    }
    println!("{}", if s != 0 { "First" } else { "Second" });
}
