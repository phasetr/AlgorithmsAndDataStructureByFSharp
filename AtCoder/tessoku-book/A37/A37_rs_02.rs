// https://atcoder.jp/contests/tessoku-book/submissions/36144214
fn main() {
    proconio::input!{n: usize, m: usize, b: usize, a: [usize; n], c: [usize; m]}
    println!("{}", a.iter().sum::<usize>() * m + b * n * m + c.iter().sum::<usize>() * n);
}
