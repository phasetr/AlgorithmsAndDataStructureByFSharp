// https://atcoder.jp/contests/tessoku-book/submissions/36150873
use std::collections::BinaryHeap;
use proconio::input;

#[proconio::fastout]
fn main() {
    input!{q: usize}
    let mut s = BinaryHeap::new();
    for _ in 0 .. q {
        input!{n: usize}
        match n {
            1 => {input!{b: isize}; s.push(-b)},
            2 => println!("{}", -s.peek().unwrap()),
            3 => {s.pop();},
            _ => ()
        }
    }
}
