// https://atcoder.jp/contests/tessoku-book/submissions/36312694
fn main() {
    proconio::input!{a: i64, b: i64, c: i64}
    let r = match a + b + c == 0 {
        true => "Yes",
        false => "No"
    };
    println!("{}", r);
}
