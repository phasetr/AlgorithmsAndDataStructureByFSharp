// https://atcoder.jp/contests/tessoku-book/submissions/36536595
use proconio::{fastout, input};
use std::cmp;

#[fastout]
fn main() {
    input! {
        n: usize,
        mut rooms: [i32; n],
        d: usize,
        lrs: [(usize, usize); d],
    }

    let l_cumulative_sum = rooms
        .iter()
        .scan(0, |max_num, room| {
            *max_num = cmp::max(*room, *max_num);
            Some(*max_num)
        })
        .collect::<Vec<_>>();

    rooms.reverse();
    let mut r_cumulative_sum = rooms
        .iter()
        .scan(0, |max_num, room| {
            *max_num = cmp::max(*room, *max_num);
            Some(*max_num)
        })
        .collect::<Vec<_>>();
    r_cumulative_sum.reverse();

    for (l, r) in lrs {
        let l_max = l_cumulative_sum[l - 2];
        let r_max = r_cumulative_sum[r];
        println!("{}", cmp::max(l_max, r_max));
    }
}
