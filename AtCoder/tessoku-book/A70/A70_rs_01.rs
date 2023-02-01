// https://atcoder.jp/contests/tessoku-book/submissions/36696065
use std::mem::swap;

use proconio::{marker::Usize1, input};

fn main()
{
    input!{n: usize, m: usize, a: [usize; n], l: [[Usize1; 3]; m]}
    let ba = a.iter().enumerate().fold(0, |x, (i, &y)| x | (y << i));
    let bl = l.iter().map(|v| v.iter().fold(0, |x, &y| x | (1 << y))).collect::<Vec<_>>();
    let len = 1 << n;
    let out = 1000;
    let mut dp1 = vec![out; len];
    let mut dp2 = vec![out; len];
    dp1[ba] = 0;
    for l in bl {
        for i in 0 .. len {
            dp2[i] = dp1[i].min(dp1[i ^ l] + 1);
        }
        swap(&mut dp1, &mut dp2);
    }
    let r = match dp1[len - 1] == out {
        true => -1,
        false => dp1[len - 1]
    };
    println!("{}", r);
}
