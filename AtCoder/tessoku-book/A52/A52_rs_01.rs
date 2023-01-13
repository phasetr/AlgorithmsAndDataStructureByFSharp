// https://atcoder.jp/contests/tessoku-book/submissions/35631468
use std::collections::VecDeque;
use proconio::input;
#[proconio::fastout]
fn main() {
    input!{
        q:i32,
    }
    let mut deq = VecDeque::new();
    for _ in 0..q{
        input!{queri:i32,}
        if queri == 1{
            input!{x:String,}
            deq.push_back(x);
        }else if queri == 2{
            println!("{}",deq[0]);
        }else{
            deq.pop_front();
        }
    }
}
