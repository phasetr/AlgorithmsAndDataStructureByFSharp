// https://atcoder.jp/contests/tessoku-book/submissions/36170237
use bitset_fixed::BitSet;
use proconio::input;

#[proconio::fastout]
fn main() {
    input! {
        n: usize,
        s: usize,
        av: [usize; n],
    }
    let mut set = BitSet::new(s + 1);
    set.set(0, true);
    for a in av {
        set.shl_or(a);
    }
    if set[s] {
        println!("Yes");
    } else {
        println!("No");
    }
}
