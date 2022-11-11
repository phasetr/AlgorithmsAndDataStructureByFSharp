// https://atcoder.jp/contests/agc018/submissions/34142912
use num::Integer;
use proconio::input;

fn main() {
    input! { n: usize, k: usize, a: [usize; n] }
    let g = a.iter().fold(0, |g, i| g.gcd(i));
    let mx = *a.iter().max().unwrap();
    if k <= mx && k % g == 0 {
        println!("{}", "POSSIBLE");
    }
    else {
        println!("{}", "IMPOSSIBLE");
    }
}
