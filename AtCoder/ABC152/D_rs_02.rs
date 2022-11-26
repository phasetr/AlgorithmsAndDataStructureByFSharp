// https://atcoder.jp/contests/abc152/submissions/31731894
use proconio::input;

fn main() {
    input! {
        n: usize,
    }

    let mut count = [[0; 10]; 10];

    for i in 1..=n {
        let mut d1 = i;
        while d1 >= 10 {
            d1 /= 10;
        }
        let d2 = i % 10;
        count[d1][d2] += 1;
    }

    let mut ans = 0;

    for d1 in 1..=9 {
        for d2 in 1..=9 {
            ans += count[d1][d2] * count[d2][d1];
        }
    }

    println!("{}", ans);
}
