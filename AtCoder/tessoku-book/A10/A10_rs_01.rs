// https://atcoder.jp/contests/tessoku-book/submissions/36927497
use proconio::{input, fastout, marker::Usize1};

#[fastout]
fn main() {
    input!{n: usize, a: [u8; n], d: usize}
    let mut lm = a.clone();
    let mut rm = a.clone();
    (1 .. n).for_each(|i| lm[i] = lm[i].max(lm[i - 1]));
    (0 .. n - 1).rev().for_each(|i| rm[i] = rm[i].max(rm[i + 1]));
    for _ in 0 .. d {
        input!{l: Usize1, r: Usize1}
        println!("{}", lm[l - 1].max(rm[r + 1]));
    }
}
