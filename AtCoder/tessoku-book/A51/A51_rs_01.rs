// https://atcoder.jp/contests/tessoku-book/submissions/35631282
use proconio::input;
#[proconio::fastout]
fn main() {
    input!{
        q:i32,
    }
    let mut data = vec![];
    for _ in 0..q{
        input!{qu:i32,}
        if qu == 1{
            input!{x:String,}
            data.push(x);
        }else if qu == 2{
            println!("{}",data[data.len()-1]);
        }else{
            data.pop();
        }
    }
}
