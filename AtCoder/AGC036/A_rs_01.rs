// https://atcoder.jp/contests/agc036/submissions/30797816
use proconio::{input};

fn main() {
    input! {s:u64}
    let m = (s as f64).sqrt().ceil() as u64;
    println!("0 0 {} {} 1 {}",m,m*m-s,m);
}
