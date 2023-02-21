// https://atcoder.jp/contests/tessoku-book/submissions/38363739
use proconio::input;

fn main() {
    input! {
        n: usize,
    }
    let mut k = 1;
    let mut result = 0;
    while k <= n {
        for i in 0..=9 {
            result += i * (n / (k * 10) * k);
            let j = n % (k * 10) + 1;
            if j > i * k {
                result += i * k.min(j - i * k);
            }
        }
        k *= 10;
    }
    println!("{}", result);
}
