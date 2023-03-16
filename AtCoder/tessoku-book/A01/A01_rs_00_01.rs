// M-x evcxr (evcxr)
extern crate proconio;
use proconio::{input, marker::Usize1};
fn solve(N:i32) -> i32 {
    N*N
}
#[proconio::fastout]
fn main() {
    input! { N: i32 }
    println!("{}", N*N);
}

fn test() {
    let N = 2;
    assert_eq!(solve(N), 4);
    let N = 100;
    assert_eq!(solve(N), 100);
}
