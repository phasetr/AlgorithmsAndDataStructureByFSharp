// https://atcoder.jp/contests/abc052/submissions/27512888
use proconio::{input, fastout};

#[fastout]
fn main() {
    input!{
        n: usize, a: i64, b: i64,
        x: [i64; n],
    }
    let mut ans = 0;
    for i in 0..n-1 {
        ans += b.min((x[i+1]-x[i])*a);
    }
    println!("{}",ans);
}
