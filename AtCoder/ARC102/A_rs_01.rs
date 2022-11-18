// https://atcoder.jp/contests/abc108/submissions/21233112
use proconio::input;

fn main() {
    input! { n: usize, k: usize };

    let mut c = (n/k).pow(3);
    if k%2 == 0 { c += ((n+k/2)/k).pow(3) }

    println!("{}", c);
}
