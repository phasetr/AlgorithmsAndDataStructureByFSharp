// https://atcoder.jp/contests/tessoku-book/submissions/36716211
use std::iter::FromIterator;
use proconio::{marker::{Usize1, Chars}, input};

fn main() {
    input!{n: usize, x: Usize1, mut c: Chars}
    for i in x .. n {
        match c[i] {
            '.' => c[i] = '@',
            '#' => break,
            _ => ()
        }
    }
    for i in (0 .. x).rev() {
        match c[i] {
            '.' => c[i] = '@',
            '#' => break,
            _ => ()
        }
    }
    println!("{}", String::from_iter(c));
}
