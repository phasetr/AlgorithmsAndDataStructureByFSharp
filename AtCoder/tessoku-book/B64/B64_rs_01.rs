// https://atcoder.jp/contests/tessoku-book/submissions/36868420
use std::{collections::BinaryHeap, cmp::Reverse};
use proconio::{input, marker::Usize1};

fn main() {
    proconio::input!{n: usize, m: usize}
    let mut g = vec![vec![]; n];
    for _ in 0 .. m {
        input!{a: Usize1, b: Usize1, c: isize}
        g[a].push((c, b));
        g[b].push((c, a));
    }
    let mut b = BinaryHeap::new();
    let mut d = vec![-1; n];
    b.push(Reverse((0, 0)));
    loop {
        let Reverse((v, i)) = b.pop().unwrap();
        if d[i] == -1 {
            d[i] = v;
            if i + 1 == n {break;}
            b.extend(g[i].iter().map(|&(w, j)| Reverse((v + w, j))));
        }
    }
    let mut s = n - 1;
    let mut r = vec![n];
    while s != 0 {
        let l = d[s];
        s = g[s].iter().find(|&&(v, i)| l - v == d[i]).unwrap().1;
        r.push(s + 1);
    }
    println!("{}", r.iter().rev().map(|v| format!("{} ", v)).collect::<String>().trim_end());
}
