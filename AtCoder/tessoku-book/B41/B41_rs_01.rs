// https://atcoder.jp/contests/tessoku-book/submissions/36717903
use proconio::{fastout, input};

#[fastout]
fn main() {
    input!{mut x: usize, mut y: usize}
    let mut r = vec![];
    while x + y > 2 {
        r.push((x, y));
        match x > y {
            true => x -= y,
            false => y -= x
        }
    }
    println!("{}", r.len());
    for (xv, yv) in r.iter().rev() {
        println!("{} {}", xv, yv);
    }
}
