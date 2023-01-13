// https://atcoder.jp/contests/tessoku-book/submissions/35632038
use std::collections::BinaryHeap;

use proconio::input;
#[proconio::fastout]
fn main() {
    input! {
        q:i32,
    }
    let mut lis = BinaryHeap::new();
    for _ in 0..q{
        input!{que:i32,}
        if que == 1{
            input! {price:i32,}
            lis.push(-price);
        }else if que == 2{
            println!("{}",-lis.peek().unwrap());
        }else{
            lis.pop();
        }
    }
}

