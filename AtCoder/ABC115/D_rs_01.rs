// https://atcoder.jp/contests/abc115/submissions/34488303
use proconio::input;

fn rec(n: usize, x: usize) -> usize {
    if n == 0 {
        1
    } else {
        let l = (1 << (n + 1)) - 3;
        let num = (1 << n) - 1;
        if x == 1 {
            0
        } else if x <= l + 1 {
            rec(n - 1, x - 1)
        } else if x == l + 2 {
            num + 1
        } else if x <= 2 * (l + 1) {
            num + 1 + rec(n - 1, x - l - 2)
        } else {
            2 * num + 1
        }
    }
}

fn main() {
    input! {
        n: usize, x: usize,
    }

    println!("{}", rec(n, x));
}
