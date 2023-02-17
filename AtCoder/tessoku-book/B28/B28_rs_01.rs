// https://atcoder.jp/contests/tessoku-book/submissions/38356194
use proconio::input;

fn main() {
    input! {
        n: usize,
    }
    const MOD: usize = 1000000007;
    let mut t = (1, 1);
    for _ in 2..n {
        t = (t.1, (t.0 + t.1) % MOD);
    }
    let result = t.1;
    println!("{}", result);
}
