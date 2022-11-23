// https://atcoder.jp/contests/abc160/submissions/19192232
#![allow(unused_macros)]
use proconio::{input, fastout};

#[fastout]
fn main() {
    input!(x: usize, y: usize, a: usize, b: usize, c: usize);
    input!(mut p: [usize; a], mut q: [usize; b], mut r: [usize; c]);
    p.sort(); q.sort();
    p.reverse(); q.reverse();
    p.truncate(x); q.truncate(y);
    p.append(&mut q);
    p.append(&mut r);
    p.sort();
    p.reverse();
    p.truncate(x+y);
    println!("{}", p.iter().sum::<usize>());
}
