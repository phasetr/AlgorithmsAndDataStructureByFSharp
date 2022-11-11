// https://atcoder.jp/contests/abc134/submissions/29395546
use itertools::Itertools;
use proconio::input;

fn main() {
    input! {
        n : usize,
        a : [usize; n]
    }

    let mut b = vec![0; n+1];
    for i in (1..=n).rev() {
        let sum = (i+i..=n).step_by(i).map(|i| b[i]).sum::<usize>() % 2;
        if sum != a[i-1] { b[i] = 1; }
    }

    println!("{}\n{}",
        b.iter().filter(|&&b| b == 1).count(),
        b.iter().positions(|&b| b== 1).join(" ")
    );
}
