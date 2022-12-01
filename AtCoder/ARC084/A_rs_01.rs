// https://atcoder.jp/contests/abc077/submissions/33060970
use proconio::input;
use superslice::Ext;
fn main() {
    input! {
        n: usize,
        mut a: [usize; n],
        mut b: [usize; n],
        mut c: [usize; n],
    }
    a.sort();
    c.sort();

    let mut count = 0;
    for bi in &b {
        let a_idx = a.lower_bound(bi);
        let c_idx = c.upper_bound(bi);
        count += a_idx * (c.len()-c_idx);
    }
    println!("{}", count);
}
