// https://atcoder.jp/contests/abc147/submissions/15692400
use proconio::input;

const MOD: usize = 1_000_000_007;

fn main() {
    input! {
        n: usize,
        ai: [usize;n]
    }

    let mut sum = 0;
    for i in 0..=60 {
        let mut count = 0;
        for v in ai.iter() {
            if *v >> i & 1 == 1 {
                count += 1;
            }
        }
        let mut s_sum = count * (n - count) % MOD;

        for ii in 0..i {
            s_sum = s_sum * 2 % MOD;
        }
        sum = s_sum + sum % MOD;
    }
    println!("{}", sum);
}
