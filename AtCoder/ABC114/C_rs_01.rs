// https://atcoder.jp/contests/abc114/submissions/18637607
use proconio::input;

fn main() {
    input!{n: i64}
    let mut ans = 0;
    solve(n, 0, 0b000, &mut ans);
    println!("{}", ans);
}

fn solve(n: i64, cur: i64, bit: u8, ans: &mut i32) {
    if cur > n {
        return;
    }
    if bit == 0b111 {
        *ans += 1;
    }
    solve(n, cur*10+7, bit|0b001, ans);
    solve(n, cur*10+5, bit|0b010, ans);
    solve(n, cur*10+3, bit|0b100, ans);
}
