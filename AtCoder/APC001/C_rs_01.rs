// https://atcoder.jp/contests/apc001/submissions/23191776
use std::io::stdin;

fn read() -> String {
    let mut buf = String::new();
    stdin().read_line(&mut buf).ok();
    buf.trim().to_string()
}

fn main() {
    let n = {
        let mut buf = String::new();
        stdin().read_line(&mut buf).ok();
        buf.trim().parse::<usize>().unwrap()
    };
    println!("0");
    let s0 = read();
    if s0 == "Vacant" {
        return;
    }
    let (mut lo, mut hi) = (1, n - 1);
    for _ in 0..20 {
        let m = (lo + hi + 1) / 2;
        println!("{}", m);
        let s = read();
        if s == "Vacant" {
            break;
        }
        if (s == s0) == (m % 2 == 0) {
            lo = m + 1;
        } else {
            hi = m - 1;
        }
    }
}
