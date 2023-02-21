// https://atcoder.jp/contests/tessoku-book/submissions/36757364
use proconio::input;

fn main() {
    input! {
        n: usize,
        s: String
    };

    let s = s.chars().collect::<Vec<char>>();
    let mut a: Vec<i64> = vec![1; n];
    for i in 0..n - 1 {
        if s[i] == 'A' {
            a[i + 1] = a[i] + 1;
        }
    }

    for i in (0..n - 1).rev() {
        if s[i] == 'B' {
            a[i] = a[i].max(a[i + 1] + 1);
        }
    }

    println!("{}", a.iter().sum::<i64>());
}
