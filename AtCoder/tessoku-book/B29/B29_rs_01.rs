// https://atcoder.jp/contests/tessoku-book/submissions/36319306
fn pow(x: u64, e: u64) -> u64 {
    let m = 1_000_000_007;
    match e {
        0 => 1,
        v if v & 1 == 0 => pow(x % m * x % m, e >> 1) % m,
        _ => x % m * pow(x % m, e - 1) % m
    }
}

fn main() {
    proconio::input!{a: u64, b: u64};
    println!("{}", pow(a, b));
}
