// https://atcoder.jp/contests/tessoku-book/submissions/35020970
use proconio::{input, fastout};
use proconio::marker::{Bytes, Chars, Usize1};

#[fastout]
fn main() {
    input!{
        n: usize,
        a: [usize; n],
        d: usize,
        p: [(Usize1, Usize1); d],
    }
    let (mut f, mut b) = (vec![0; n+1], vec![0; n+1]);
    for i in 0..n {
        f[i+1] = f[i].max(a[i]);
        b[n-i-1] = b[n-i].max(a[n-i-1]);
    }
    for (l, r) in p {
        println!("{}", f[l].max(b[r+1]));
    }
}
