// https://atcoder.jp/contests/abc152/submissions/26684023
use proconio::{fastout, input};

#[fastout]
fn main() {
    input! {
        n: usize,
    }
    let mut v = [[0; 10]; 10];
    for i in 1..=n {
        let j = (i.to_string().bytes().next().unwrap() - b'0') as usize;
        v[j][i % 10] += 1;
    }
    let mut answer = 0;
    for i in 0..10 {
        for j in 0..10 {
            answer += v[i][j] * v[j][i];
        }
    }
    println!("{}", answer);
}
