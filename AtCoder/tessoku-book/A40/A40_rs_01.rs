// https://atcoder.jp/contests/tessoku-book/submissions/36152599
fn main() {
    proconio::input!{n: usize, a: [usize; n]}
    let mut s = vec![0i64; 101];
    a.iter().for_each(|&v| s[v] += 1);
    println!("{}", s.iter().map(|&v| v * (v - 1) * (v - 2) / 6).sum::<i64>());
}
