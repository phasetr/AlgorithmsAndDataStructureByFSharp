// https://atcoder.jp/contests/tessoku-book/submissions/36318912
use proconio::{input, marker::Bytes};

fn main() {
    input!{_: usize, k: usize, s: Bytes}
    let r = match (k + s.iter().filter(|&&c| c == b'1').count()) & 1 == 0 {
        true => "Yes",
        false => "No"
    };
    println!("{}", r);
}
