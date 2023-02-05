// https://atcoder.jp/contests/tessoku-book/submissions/36219253
fn main() {
    proconio::input!{l: usize, r: usize}
    let r = match (l ..= r).any(|v| 100 % v == 0) {
        true => "Yes",
        false => "No"
    };
    println!("{}", r);
}
