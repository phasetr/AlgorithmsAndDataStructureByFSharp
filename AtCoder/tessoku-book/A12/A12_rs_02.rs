// https://atcoder.jp/contests/tessoku-book/submissions/37454380
use proconio::input;
fn main() {
    input!{
        n: usize,
        k: usize,
        a: [usize; n],
    }

    let mut lo = 1;
    let mut hi = 10_usize.pow(9);
    while lo < hi {
        let mid = (hi + lo) / 2;
        let sum = a.iter().map(|x| mid / x).sum();
        if k <= sum {
            hi = mid;
        } else {
            lo = mid + 1;
        }
    }
    println!("{}", lo);
}
