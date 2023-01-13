// https://atcoder.jp/contests/tessoku-book/submissions/36150986
use std::collections::HashMap;
use proconio::input;

#[fastout]
fn main() {
    input!{q: usize}
    let mut s = HashMap::new();
    for _ in 0 .. q {
        input!{n: usize}
        match n {
            1 => {input!{h: String, b: usize}; s.insert(h, b);},
            2 => {input!{h: String}; println!("{}", s[&h])},
            _ => ()
        }
    }
}
