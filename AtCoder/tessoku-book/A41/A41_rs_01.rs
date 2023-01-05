// https://atcoder.jp/contests/tessoku-book/submissions/37118190
fn main() {
    proconio::input!{_: usize, s: String}
    match s.find("RRR").or_else(|| s.find("BBB")) {
        Some(_) => println!("Yes"),
        None => println!("No")
    }
}
