// https://atcoder.jp/contests/abc112/submissions/25366484
use num_integer::Roots;
use superslice::Ext;

fn main() {
    proconio::input! {
        n: usize,
        m: usize,
    }

    let mut ds = vec![];
    let mut d = 1;
    while d * d <= m {
        if m % d == 0 {
            ds.push(d);
            ds.push(m / d);
        }
        d += 1;
    }

    ds.sort();

    println!("{}", ds[ds.upper_bound(&(m / n)) - 1]);
}
