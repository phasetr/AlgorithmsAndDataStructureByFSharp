// https://atcoder.jp/contests/abc048/submissions/27631101
use proconio::{input, fastout};

#[fastout]
fn main() {
    input!{
        n: usize, x: i64,
        a: [i64; n],
    }
    let mut ans = 0;
    let mut carry = 0;
    for ai in a {
        let diff = (carry + ai - x).max(0);
        ans += diff;
        carry = ai - diff;
    }
    println!("{}", ans);
}
