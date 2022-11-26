// https://atcoder.jp/contests/agc023/submissions/36127719
use std::collections::HashMap;

use proconio::input;

fn main() {
    input! {
        n: usize,
        a: [i64; n],
    }
    let mut mp = HashMap::new();
    mp.insert(0, 1_i64);
    let mut res = 0;
    let mut s = 0;
    for &x in &a {
        s += x;
        res += mp.get(&s).unwrap_or(&0);
        mp.entry(s).and_modify(|c| *c += 1).or_insert(1);
    }
    println!("{}", res);
}
