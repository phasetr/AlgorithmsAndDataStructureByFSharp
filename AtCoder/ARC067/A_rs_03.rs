// https://atcoder.jp/contests/abc052/submissions/23870214
use proconio::input;

fn main() {
    input! {
        n: usize
    }

    let mut count = vec![0_usize; n + 1];

    for i in 2..=n {
        let mut x = i;
        for j in 2..=n {
            if j > x {
                break;
            }
            while x % j == 0 {
                x /= j;
                count[j] += 1;
            }
        }
        if x != 1 {
            count[x] += 1;
        }
    }

    let r = count.into_iter().fold(1, |acc, x| {
        if x == 0 {
            acc
        } else {
            acc * (x + 1) % 1_000_000_007
        }
    });

    println!("{}", r);
}
