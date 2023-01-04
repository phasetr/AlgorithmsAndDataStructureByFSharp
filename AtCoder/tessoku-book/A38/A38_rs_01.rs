// https://atcoder.jp/contests/tessoku-book/submissions/36151892
#![allow(clippy::needless_range_loop)]

fn main() {
    proconio::input!{d: usize, n: usize, q: [(usize, usize, usize); n]}
    let mut t = vec![24; d + 1];
    for (l, r, h) in q {
        for i in l ..= r {
            t[i] = t[i].min(h);
        }
    }
    println!("{}", t.iter().skip(1).sum::<usize>());
}
