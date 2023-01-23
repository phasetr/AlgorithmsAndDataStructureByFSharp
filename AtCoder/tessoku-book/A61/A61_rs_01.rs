// https://atcoder.jp/contests/tessoku-book/submissions/35981422
use proconio::{input, marker::Usize1};
use itertools::Itertools;
#[proconio::fastout]
fn main() {
    input!{
        n:usize,m:i32,
        abm:[(Usize1,Usize1);m],
    }
    let mut ans = vec![vec![];n];
    for (a,b) in abm{
        ans[a].push(b+1);
        ans[b].push(a+1);
    }
    for i in 0..n{
        println!("{}: {{{}}}",i+1,ans[i].iter().join(", "));
    }
}
