// https://atcoder.jp/contests/tessoku-book/submissions/35564600
#![allow(non_snake_case)]
use proconio::{fastout, input};
use rand::prelude::*;

const N: usize = 100;
const Q: usize = 1000;

fn main() {
    input! {
        A: [[usize; N]; N]
    }
    let mut X = vec![0; Q];
    let mut Y = vec![0; Q];
    let mut H = vec![0; Q];

    let mut rng = SmallRng::seed_from_u64(50);

    for i in 0..Q {
        X[i] = rng.gen_range(0, N);
        Y[i] = rng.gen_range(0, N);
        H[i] = 1;
    }

    show_result(&X, &Y, &H);
}

#[fastout]
fn show_result(X: &Vec<usize>, Y: &Vec<usize>, H: &Vec<usize>) {
    println!("1000");
    for i in 0..Q {
        println!("{} {} {}", X[i], Y[i], H[i]);
    }
}
