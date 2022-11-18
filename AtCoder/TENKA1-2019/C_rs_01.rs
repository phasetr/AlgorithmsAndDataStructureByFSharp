// https://atcoder.jp/contests/tenka1-2019/submissions/5063056
use std::io::*;
use std::str::FromStr;

fn main() {
    let n: usize = read();
    let s: Vec<char> = read::<String>().chars().collect();

    let mut white = 0;
    for i in 0..n {
        if s[i] == '.' {
            white += 1;
        }
    }

    let mut ans = white;
    let mut cnt = 0;
    for i in 0..n {
        if s[i] == '.' {
            cnt += 1;
        }
        let po = i+1 - cnt + white-cnt;
        ans = std::cmp::min(ans, po);
    }

    println!("{}", ans);
}

fn read<T: FromStr>() -> T {
    let stdin = stdin();
    let stdin = stdin.lock();
    let token: String = stdin
        .bytes()
        .map(|c| c.unwrap() as char)
        .skip_while(|c| c.is_whitespace())
        .take_while(|c| !c.is_whitespace())
        .collect();
    token.parse().ok().unwrap()
}
