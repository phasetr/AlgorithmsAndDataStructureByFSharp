// https://atcoder.jp/contests/tessoku-book/submissions/37015073
use proconio::{input, fastout, marker::{Bytes, Usize1}};

#[fastout]
fn main() {
    input!{n: usize,q: usize,s: Bytes,}
    for _ in 0..q {
        input!{a: Usize1, b: Usize1, c: Usize1, d: Usize1};
        println!("{}", if s[a..=b] == s[c..=d] {"Yes"} else {"No"});
    }
}

