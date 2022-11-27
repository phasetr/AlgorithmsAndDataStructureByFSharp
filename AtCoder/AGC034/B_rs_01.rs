// https://atcoder.jp/contests/agc034/submissions/22740445
use proconio::input;

fn main() {
    input! { mut s : String }
    s = s.replace("BC", "-");

    let mut a : u64 = 0;
    let mut ans : u64 = 0;

    for c in s.chars() {
        if c == 'A' { a += 1 }
        else if c == '-' { ans += a; }
        else { a = 0; }
    }

    println!("{}", ans);
}
