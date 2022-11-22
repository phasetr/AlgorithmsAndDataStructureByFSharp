// https://atcoder.jp/contests/abc145/submissions/20049206
use proconio::input;

const MOD: usize = 1_000_000_007;

fn fexp(mut x: usize, mut y: usize) -> usize {
    let mut ans = 1usize;
    while y > 0 {
        if y & 1 == 1 {
            ans = ans * x % MOD;
        }
        x = x * x % MOD;
        y >>= 1;
    }
    ans
}

fn comb(n: usize, k: usize) -> usize {
    let mut ans = 1;
    for i in 0..k {
        ans = ans * (n - i) % MOD * fexp(i + 1, MOD - 2) % MOD;
    }
    ans
}

fn main() {
    input! {
        x: usize,
        y: usize,
    }

    if (x + y) % 3 != 0 || 2 * x < y || 2 * y < x {
        println!("0");
    } else {
        let turns = (x + y) / 3;
        let two_in_x = x - turns;
        println!("{}", comb(turns, two_in_x));
    }
}
