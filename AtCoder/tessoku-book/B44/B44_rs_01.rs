// https://atcoder.jp/contests/tessoku-book/submissions/36859953
use proconio::{input, fastout, marker::Usize1};

#[fastout]
fn main() {
    input!{n: usize, a: [[u8; n]; n], q: usize}
    let mut p = a.iter().collect::<Vec<_>>();
    for _ in 0 .. q {
        input! {k: usize, x: Usize1, y: Usize1}
        if k == 1 {
            p.swap(x, y);
        } else {
            println!("{}", p[x][y]);
        }
    }
}
