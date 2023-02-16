// https://atcoder.jp/contests/tessoku-book/submissions/36714738
use bitset_fixed::BitSet;
use proconio::{fastout, input};

#[fastout]
fn main() {
    input!{n: usize}
    let mut b = BitSet::new(n + 1);
    for i in 2 ..= n {
        if !b[i] {
            println!("{}", i);
            for j in 2 ..= n / i {
                b.set(i * j, true);
            }
        }
    }
}
