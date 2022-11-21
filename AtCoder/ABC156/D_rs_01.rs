// https://atcoder.jp/contests/abc156/submissions/20836091
use proconio::{fastout, input};
#[fastout]
fn main() {
    input! {
        n:u64,
        a:u64,
        b:u64,
    };
    let ans = (mod_pow(2, n) + MOD * 2 - comb(n, a) - comb(n, b) - 1) % MOD;
    println!("{}", ans);
}

const MOD: u64 = 1_000_000_007;

fn mod_pow(r: u64, mut n: u64) -> u64 {
    let mut t = 1;
    let mut s = r;
    while n > 0 {
        if n & 1 == 1 {
            t = t * s % MOD;
        }
        s = s * s % MOD;
        n >>= 1;
    }
    t
}

fn comb(n: u64, k: u64) -> u64 {
    let mut nu = 1;
    let mut de = 1;
    for i in 0..k {
        nu = nu * (n - i) % MOD;
        de = de * (i + 1) % MOD;
    }
    nu * mod_pow(de, MOD - 2) % MOD
}
