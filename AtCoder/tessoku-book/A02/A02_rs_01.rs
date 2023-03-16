// https://atcoder.jp/contests/tessoku-book/submissions/36115321
fn main() {
    proconio::input!{n: usize, x: usize, a: [usize; n]};
    let r = match a.iter().any(|&v| v == x) {
        true => "Yes",
        false => "No"
    };
    println!("{}", r);
}
