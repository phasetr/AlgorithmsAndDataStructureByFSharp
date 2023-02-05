// https://atcoder.jp/contests/tessoku-book/submissions/37693949
use proconio::{input, fastout};
use std::collections::VecDeque;
use superslice::Ext as _;

static MOD:isize = 1000000007;

#[fastout]
fn main() {
    input! {
        n: usize, w: usize, l: usize, r: usize,
        xs: [usize; n]
    }

    let xs = [&[0], xs.as_slice(), &[w]].concat();

    let mut v = vec![0isize; n+4];
    v[0] = 1;
    v[1] = -1;

    let mut s = 0;

    for i in 0..=n+1 {
        let pos = xs[i];
        s += v[i];
        s %= MOD;
        let lp = xs.lower_bound(&(pos+l));
        let rp = xs.upper_bound(&(pos+r));
        v[lp] += s;
        v[lp] %= MOD;
        v[rp] = (v[rp] + MOD - s % MOD) % MOD;
    }

    println!("{}", s % MOD);
}
