// https://atcoder.jp/contests/tessoku-book/submissions/36146041
#![allow(non_snake_case)]
use std::cmp::Reverse;

use proconio::input;

fn main() {
    input! {
        N: usize,
        K: usize,
        mut LR: [(usize, usize); N]
    }
    for i in 0..N {
        LR[i].1 += K;
    }
    let ori_LR = LR.clone();

    LR.sort_by_key(|x| x.1);

    let T = 200_000;

    let mut cntL = vec![0usize; T];
    let mut now = 0;
    for &(L, R) in LR.iter() {
        if now <= L {
            cntL[R] = cntL[now] + 1;
            now = R;
        }
    }

    LR.sort_by_key(|x| Reverse(x.0));

    let mut cntR = vec![0usize; T];
    let mut now = T - 1;
    for &(L, R) in LR.iter() {
        if now >= R {
            cntR[L] = cntR[now] + 1;
            now = L;
        }
    }

    for i in 0..T - 1 {
        cntL[i + 1] = cntL[i + 1].max(cntL[i]);
    }
    for i in (0..T - 1).rev() {
        cntR[i] = cntR[i].max(cntR[i + 1]);
    }

    for &(L, R) in ori_LR.iter() {
        println!("{}", cntL[L] + 1 + cntR[R]);
    }
}
