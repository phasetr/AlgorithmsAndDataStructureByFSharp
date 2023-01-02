// https://atcoder.jp/contests/tessoku-book/submissions/36216343
use proconio::{fastout, input};

#[fastout]
fn main() {
    input!{n: usize, q: [(char, isize); n]}
    let m = 10000;
    let mut r = 0;
    for (c, v) in q {
        r = match c {
            x if x == '+' => r + v,
            x if x == '*' => r * v,
            x if x == '-' => {
                let mut t = r - v;
                if t < 0 { t += m; }
                t
            },
            _ => r
        };
        r %= m;
        println!("{}", r);
    }
}
