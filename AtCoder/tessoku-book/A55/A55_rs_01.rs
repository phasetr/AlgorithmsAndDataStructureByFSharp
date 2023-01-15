// https://atcoder.jp/contests/tessoku-book/submissions/35633206
use std::collections::BTreeSet;
use proconio::input;
#[proconio::fastout]
fn main() {
    input!{
        q:i32,
    }
    let mut bts = BTreeSet::new();
    for _ in 0..q{
        input!{queri:i32,}
        if queri == 1{
            input!{x:i32,}
            bts.insert(x);
        }else if queri == 2{
            input!{x:i32,}
            bts.remove(&x);
        }else{
            input!{x:i32,}
            println!("{}",bts.range(x..).next().unwrap_or(&-1));
        }
    }
}
