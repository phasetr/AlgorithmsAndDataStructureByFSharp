// https://atcoder.jp/contests/abc147/submissions/36135280
use proconio::input;

const MOD: i64 = 1000000007;

fn main() {
    input! {
        n: i64,
        a: [usize; n],
    }
    let mut sum: i64 = 0;
    for i in 0..60 {
        let mut cnt: i64 = 0;
        for j in 0..n {
            if ((a[j as usize] >> i) & 1) != 0 {
                cnt += 1;
            }
        }
        let dgt: i64 = (1 << i) % MOD;
        sum += (dgt * cnt % MOD * (n - cnt) % MOD) % MOD;
        sum %= MOD;
    }
    println!("{}", sum);
}
