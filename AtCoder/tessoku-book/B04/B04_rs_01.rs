// https://atcoder.jp/contests/tessoku-book/submissions/35015228
use proconio::input;
fn main() {
    input!{
        n:String,
    }
    println!("{}",i32::from_str_radix(&n, 2).unwrap());
}
