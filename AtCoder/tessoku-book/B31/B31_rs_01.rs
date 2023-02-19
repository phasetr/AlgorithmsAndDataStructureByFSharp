// https://atcoder.jp/contests/tessoku-book/submissions/37413319
fn main() {
    proconio::input! {
        n: i64
    };

    println!("{}", n / 3 + n / 5 + n / 7 - n / 15 - n / 35 - n / 21 + n / 105);
}
