// https://atcoder.jp/contests/tessoku-book/submissions/36138710
use proconio::{fastout, input};

#[fastout]
fn main() {
    input!{n: usize, mut c: [usize; n], q: usize, x: [usize; q]}
    c.sort();
    (1 .. n).for_each(|i| c[i] += c[i - 1]);
    for m in x {
        let r = match c.binary_search(&m) {
            Ok(v) => v + 1,
            Err(v) => v
        };
        println!("{}", r);
    }
}
