// https://atcoder.jp/contests/tessoku-book/submissions/36143556
use bitset_fixed::BitSet;

fn main() {
    proconio::input!{n: usize, s: usize, a: [usize; n]};
    let mut b = BitSet::new(s + 1);
    b.set(0, true);
    a.iter().for_each(|&v| b.shl_or(v));
    let r = match b[s] {
        true => "Yes",
        false => "No"
    };
    println!("{}", r);
}
