// https://atcoder.jp/contests/apc001/submissions/30743870
use proconio::{input};

fn main() {
    input! {n:usize,mut an:[i64;n],mut bn:[i64;n]}
    let ans = an.iter().zip(bn.iter()).fold(0,|mut ans,(a,b)|{
        ans += if a >= b{ (b-a) }else{ (b-a)/2 };
        ans
    });
    println!("{}",if ans >= 0 {"Yes"} else {"No"});
}
