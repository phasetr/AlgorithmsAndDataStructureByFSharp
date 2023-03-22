// https://atcoder.jp/contests/tessoku-book/submissions/36464610
use std::collections::HashSet;
use proconio::input;

#[proconio::fastout]
fn main() {
    input! { n: usize, k: i32, a: [i32; n], b: [i32; n], c: [i32; n], mut d: [i32; n] }

    let mut set = HashSet::new();
    for i in 0..n {
        for j in 0..n {
            set.insert(c[i] + d[j]);
        }
    }

    for i in 0..n {
        for j in 0..n {
            let x = k - a[i] - b[j];
            if set.contains(&x) { println!("Yes"); return; }
        }
    }

    println!("No");
}
