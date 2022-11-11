// https://atcoder.jp/contests/abc052/submissions/17142610
use proconio::input;

fn main() {
    input! {
        n: usize,
    };
    let mut p = vec![0; n + 1];
    for i in 1..=n {
        let mut m = i;
        for j in 2..=n {
            while m % j == 0 {
                m /= j;
                p[j] += 1;
            }
        }
    }
    let mut prod = 1_usize;
    for &p_i in p.iter() {
        if p_i > 0 {
            prod *= p_i + 1;
            prod %= 1_000_000_007;
        }
    }
    let ans = prod;
    println!("{}", ans);
}

