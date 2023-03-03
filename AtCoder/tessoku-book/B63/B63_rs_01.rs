// https://atcoder.jp/contests/tessoku-book/submissions/38507530
use std::{cmp::Reverse, collections::BinaryHeap};

use proconio::{input, marker::Chars};

fn main() {
    input! {
        r: usize,
        c: usize,
        sy: usize,
        sx: usize,
        gy: usize,
        gx: usize,
        cs: [Chars; r],
    }

    let mut bs = vec![vec![false; c + 2]; r + 2];
    for y in 0..r {
        for x in 0..c {
            bs[y + 1][x + 1] = cs[y][x] == '.';
        }
    }

    let mut heap = BinaryHeap::new();
    heap.push((Reverse(0usize), sy, sx));
    while let Some((Reverse(step), y, x)) = heap.pop() {
        if !bs[y][x] {
            continue;
        }
        if y == gy && x == gx {
            println!("{}", step);
            break;
        }
        bs[y][x] = false;
        for &(dy, dx) in &[(0, 1), (0, -1), (1, 0), (-1, 0)] {
            let (y, x) = ((y as i64 + dy) as usize, (x as i64 + dx) as usize);
            if bs[y][x] {
                heap.push((Reverse(step + 1), y, x));
            }
        }
    }
}
