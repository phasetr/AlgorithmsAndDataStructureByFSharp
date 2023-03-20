// https://atcoder.jp/contests/tessoku-book/submissions/36143620
#[proconio::fastout]
fn main() {
    proconio::input!{n: usize, x: usize, a: [usize; n]}
    println!("{}", a.binary_search(&x).unwrap() + 1);
}
