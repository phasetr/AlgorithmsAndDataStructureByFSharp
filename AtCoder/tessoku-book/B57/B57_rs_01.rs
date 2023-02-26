// https://atcoder.jp/contests/tessoku-book/submissions/37895581
use proconio::input;
fn main() {
    input! {
        n: usize,
        mut k: usize,
    }

    let mut res = (0..=n).collect::<Vec<_>>();
    let mut doubling = (0..=n).map(|i| i - sum_number(i)).collect::<Vec<_>>();

    while k > 0 {
        if (k & 1) != 0 {
            res = (0..=n).map(|i| doubling[res[i]]).collect::<Vec<_>>();
        }
        doubling = (0..=n).map(|i| doubling[doubling[i]]).collect::<Vec<_>>();
        k >>= 1;
    }

    println!("{}", (1..=n).map(|i| res[i].to_string()).collect::<Vec<_>>().join("\n"));
}

fn sum_number(mut n: usize) -> usize {
    let mut sum = 0;
    while n > 0 {
        sum += n % 10;
        n /= 10;
    }
    return sum;
}
