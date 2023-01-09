// https://atcoder.jp/contests/tessoku-book/submissions/37118300
use proconio::{marker::Bytes, input};

fn main() {
    input!{n: usize, c: char, a: Bytes}
    let f = |b: u8| if b == b'W'{0} else if b == b'B'{1} else {2};
    match a.iter().map(|&v| f(v)).sum::<usize>() % 3 == f(c as u8) {
        true => println!("Yes"),
        false => println!("No")
    }
}
