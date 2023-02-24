// https://atcoder.jp/contests/tessoku-book/submissions/36312666
use proconio::{input, marker::Bytes, fastout};

#[fastout]
fn main() {
    input!{s: Bytes}
    let mut c = vec![];
    for (i, &v) in s.iter().enumerate() {
        if v == b'(' {
            c.push(i + 1);
        } else {
            let l = c.pop().unwrap();
            println!("{} {}", l, i + 1);
        }
    }
}
