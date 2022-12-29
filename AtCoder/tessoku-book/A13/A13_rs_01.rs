// https://atcoder.jp/contests/tessoku-book/submissions/36143954
fn main() {
    proconio::input!{n: usize, k: usize, a: [usize; n]}
    let mut r = 0;
    for i in 0 .. n {
        r += match a.binary_search(&(a[i] + k)) {
            Ok(x) => x - i,
            Err(x) => x - 1 - i
        };
    }
    println!("{}", r);
}
