// https://atcoder.jp/contests/tessoku-book/submissions/36116430
use proconio::{marker::Usize1, fastout, input};

#[fastout]
fn main()
{
    input!{n: usize, q: usize, mut a: [usize; n], t: [(Usize1, Usize1); q]}
    (1..n).for_each(|i| a[i] += a[i - 1]);
    for (l, r) in t {
        let lv = match l {
            0 => 0,
            _ => a[l - 1]
        };
        println!("{}", a[r] - lv);
    }
}
