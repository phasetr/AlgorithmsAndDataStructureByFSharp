// https://atcoder.jp/contests/tessoku-book/submissions/37408230
use proconio::input;

fn main() {
    input! {
        n: usize,
    };
    println!("{}", n);
    for i in 0..n {
        println!("{} {}", i + 1, (i + 1) % n + 1);
    }
}
