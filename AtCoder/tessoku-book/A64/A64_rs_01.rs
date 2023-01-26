// https://atcoder.jp/contests/tessoku-book/submissions/36841853
use std::{collections::BinaryHeap, cmp::Reverse};
use proconio::{input, marker::Usize1, fastout};

#[fastout]
fn main()
{
    input!{n: usize, m: usize}
    let mut g = vec![vec![]; n];
    for _ in 0 .. m
    {
        input!{a: Usize1, b: Usize1, c: usize}
        g[a].push((b, c));
        g[b].push((a, c));
    }
    let mut d = vec![None; n];
    let mut b = BinaryHeap::new();
    b.push(Reverse((0, 0)));
    while !b.is_empty()
    {
        let Reverse((v, i)) = b.pop().unwrap();
        if d[i].is_none()
        {
            d[i] = Some(v as isize);
            b.extend(g[i].iter().filter(|&&(j, _)| d[j].is_none()).map(|&(j, w)| Reverse((v + w, j))));
        }
    }
    for v in d
    {
        println!("{}", v.unwrap_or(-1));
    }
}
