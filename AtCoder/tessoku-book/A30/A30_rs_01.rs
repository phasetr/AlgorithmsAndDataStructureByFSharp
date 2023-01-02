// https://atcoder.jp/contests/tessoku-book/submissions/36730785
const MOD: u64 = 1000000007;

fn fact(n: u64) -> u64 {
    (1 ..= n).fold(1, |x, y| x * y % MOD)
}

fn pow(x: u64, e: u64) -> u64 {
    match e {
        0 => 1,
        v if v & 1 == 0 => pow(x * x % MOD, e >> 1) % MOD,
        _ => x % MOD * pow(x, e - 1) % MOD
    }
}

fn div(a: u64, b: u64) -> u64 {
    a * pow(b, MOD - 2) % MOD
}

fn ncr(n: u64, r: u64) -> u64 {
    let a = fact(n);
    let b = fact(r) * fact(n - r) % MOD;
    div(a, b)
}

fn main() {
    proconio::input!{n: u64, r: u64}
    println!("{}", ncr(n, r));
}
