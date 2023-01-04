// https://atcoder.jp/contests/tessoku-book/submissions/35435427
use proconio::input;
#[proconio::fastout]
fn main() {
    input!{
        n:usize,m:usize,b:usize,
        a:[usize;n],
        c:[usize;m],
    }
    println!("{}",a.iter().sum::<usize>() * m + c.iter().sum::<usize>() * n + b*n*m);
}
