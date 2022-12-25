// https://atcoder.jp/contests/code-festival-2017-quala/submissions/14481327
#![allow(unused_imports)]
use std::cmp::*;
use std::collections::*;
use itertools::Itertools;
use num::clamp;
use proconio::{input, marker::*, fastout};
use superslice::*;

#[fastout()]
fn main() {
    input! {
        h: usize, w: usize,
        a: [Chars; h]
    }

    let mut map = HashMap::new();
    for s in a {
        for c in s {
            *map.entry(c).or_insert(0) += 1;
        }
    }

    let need_fours = (h/2) * (w/2);
    let mut fours = 0;
    let mut ones = 0;
    for &v in map.values() {
        fours += v / 4;
        ones += v % 2;
    }
    let ans = if need_fours > fours {
        false
    } else if h % 2 == 1 && w % 2 == 1 {
        ones == 1
    } else {
        ones == 0
    };
    if ans {
        println!("Yes");
    } else {
        println!("No");
    }
}
