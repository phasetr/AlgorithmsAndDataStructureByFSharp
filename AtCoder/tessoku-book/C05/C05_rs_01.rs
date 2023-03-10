// https://atcoder.jp/contests/tessoku-book/submissions/37660839
use proconio::input;
#[proconio::fastout]
fn main() {
    input! {
        n:usize,
    }
    let ans = format!("{:010b}", n - 1);
    println!("{}", ans.replace("0", "4").replace("1", "7"));
}
