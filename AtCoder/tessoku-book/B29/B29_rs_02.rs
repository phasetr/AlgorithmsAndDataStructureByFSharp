// https://atcoder.jp/contests/tessoku-book/submissions/35403610
use proconio::input;

const MOD: i64 = 1_000_000_007;

fn pow(mut a: i64, mut b: i64) -> i64 {
    let mut r = 1;
    while b > 0 {
        if b & 1 == 1 {
            r = r * a % MOD;
        }
        a = a * a % MOD;
        b >>= 1;
    }
    r
}

fn main() {
    input! {
        a: i64,
        b: i64,
    }
    println!("{}", pow(a, b));
}
