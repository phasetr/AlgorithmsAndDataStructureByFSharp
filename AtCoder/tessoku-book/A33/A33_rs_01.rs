// https://atcoder.jp/contests/tessoku-book/submissions/37267684
fn main() {
    proconio::input!{n: usize, a: [usize; n]}
    match a.iter().fold(0, |x, &y| x ^ y) {
        0 => println!("Second"),
        _ => println!("First")
    }
}
