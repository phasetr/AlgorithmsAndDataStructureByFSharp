// https://atcoder.jp/contests/tessoku-book/submissions/36216548
fn pow(a: usize, b: usize) -> usize {
    let m = 1_000_000_000 + 7;
    match b {
        0 => 1,
        x if x & 1 == 0 => pow(a * a % m, b >> 1),
        _ => a * pow(a, b - 1) % m
    }
}

fn main() {
    proconio::input!{a: usize, b: usize}
    println!("{}", pow(a, b));
}
