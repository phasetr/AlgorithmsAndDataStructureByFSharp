// https://atcoder.jp/contests/agc038/submissions/27972273
use proconio::input;
fn main() {
    input! {
        h: usize,
        w: usize,
        a: usize,
        b: usize
    }

    for r in 0..h {
        for c in 0..w {
            if (r < b && c >= a) || (r >= b && c < a) {
                print!("1");
            } else {
                print!("0");
            }
        }
        println!();
    }
}

