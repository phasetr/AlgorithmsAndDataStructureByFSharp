// https://atcoder.jp/contests/tessoku-book/submissions/36549022
use proconio::{fastout, input};
use superslice::Ext;

#[fastout]
fn main() {
    input! {
        n: usize,
        mut arr: [i32; n],
        q: usize,
        qs: [i32; q],
    }

    arr.sort();
    for x in qs {
        println!("{}", arr.lower_bound(&x));
    }
}
