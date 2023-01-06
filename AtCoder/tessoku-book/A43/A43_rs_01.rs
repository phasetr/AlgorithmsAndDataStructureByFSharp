// https://atcoder.jp/contests/tessoku-book/submissions/37118478
use proconio::input;

fn main() {
    input!{n: usize, l: usize}
    let mut r = 0;
    for _ in 0 .. n {
        input!{a: usize, b: char}
        r = match b {
            'E' => r.max(l - a),
            _ => r.max(a)
        }
    }
    println!("{}", r);
}
