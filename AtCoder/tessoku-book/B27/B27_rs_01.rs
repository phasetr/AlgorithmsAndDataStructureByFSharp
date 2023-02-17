// https://atcoder.jp/contests/tessoku-book/submissions/36319564
use num::Integer;
use proconio::input;

fn main() {
    input!{a: u64, b: u64}
    println!("{}", a.lcm(&b));
}
