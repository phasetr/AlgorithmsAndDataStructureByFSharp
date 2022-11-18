// https://atcoder.jp/contests/abc108/submissions/31430645
use proconio::input;
fn main() {
    input! {
        n: usize,
        k: usize,
    }
    let mut result = triple(n / k);
    if k & 1 == 0 {
        result += triple((n + (k / 2)) / k);
    }
    println!("{}", result);
}

fn triple(x: usize) -> usize {
    x * x * x
}
