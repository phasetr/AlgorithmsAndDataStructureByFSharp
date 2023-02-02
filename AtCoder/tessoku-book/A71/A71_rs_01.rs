// https://atcoder.jp/contests/tessoku-book/submissions/38009531
use proconio::input;

fn main() {
    input! {
        n: usize,
        mut a: [usize; n],
        mut b: [usize; n],
    }

    a.sort();
    b.sort();
    let result: usize = (0..n).map(|i| a[i] * b[n - i - 1]).sum();
    println!("{}", result);
}
