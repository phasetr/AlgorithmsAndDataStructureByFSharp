// https://atcoder.jp/contests/abc077/submissions/27280251
use proconio::{input, fastout};

#[fastout]
fn main() {
    input!{
        n: usize,
        mut a: [i32; n],
        mut b: [i32; n],
        mut c: [i32; n],
    }
    a.sort(); b.sort(); c.sort();
    let mut ans = 0;
    let mut i = 0;
    let mut k = 0;
    for j in 0..n {
        while i < n-1 && a[i+1] < b[j] { i += 1; }
        while k < n-1 && !(b[j] < c[k]) { k += 1; }
        if a[i] < b[j] && b[j] < c[k] { ans += (i+1) * (n-k); }
    }
    println!("{}", ans);
}
