// https://atcoder.jp/contests/tessoku-book/submissions/36740162
use std::collections::HashMap;
use proconio::input;

const MOD: u64 = 1000000007;
fn pow(x: u64, e: u64) -> u64 {
    match e {
        0 => 1,
        v if v & 1 == 0 => pow(x * x % MOD, e >> 1),
        _ => x * pow(x, e - 1) % MOD
    }
}

fn main() {
    input!{n: u64, p: u64}
    let mut h = HashMap::new();
    let mut r = 0u64;
    let m = 1000000007;
    for i in 1 ..= n {
        input!{a: u64}
        let a = a % m;
        r += match a {
            0 => match p {
                0 => i - 1,
                _ => 0
            }
            _ => *(h.get(&(p * pow(a, MOD - 2) % MOD)).unwrap_or(&0))
        };
        *h.entry(a).or_default() += 1;
    }
    println!("{}", r);
}
