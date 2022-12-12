// https://atcoder.jp/contests/agc038/submissions/18642671
// :fu:

use proconio::input;

fn main() {
    input! {
        h: usize,
        w: usize,
        a: usize,
        b: usize,
    }

    let mut vs = Vec::with_capacity(w);
    for _ in 0..a {
        vs.push('0');
    }
    for _ in 0..w - a {
        vs.push('1');
    }
    let s = vs.iter().collect::<String>();
    for _ in 0..b {
        println!("{}", s);
    }

    let mut vs = Vec::with_capacity(w);
    for _ in 0..a {
        vs.push('1');
    }
    for _ in 0..w - a {
        vs.push('0');
    }
    let s = vs.iter().collect::<String>();
    for _ in 0..h - b {
        println!("{}", s);
    }

}
