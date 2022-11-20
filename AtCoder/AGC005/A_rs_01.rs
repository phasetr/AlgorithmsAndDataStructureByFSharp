// https://atcoder.jp/contests/agc005/submissions/35237400
use proconio::input;

fn main() {
    input! {
        s: String,
    };
    let mut stack = 0;
    for c in s.chars() {
        if c == 'T' {
            if stack > 0 {
                stack -= 1;
            }
        } else {
            stack += 1;
        }
    }
    println!("{}", stack * 2);
}
