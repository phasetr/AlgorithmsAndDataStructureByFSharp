// https://atcoder.jp/contests/panasonic2020/submissions/33221049
use itertools::Itertools;
use proconio::input;

fn main() {
    input! {
        n : u8,
    }

    let mut ans = vec![];
    f(0, n, &mut String::new(), &mut ans);
    println!("{}", ans.into_iter().join("\n"));
}

fn f(i:u8, n:u8, s:&mut String, ans:&mut Vec<String>) {
    if s.len() == n as usize { ans.push(s.clone()); return; }

    for c in 0..=i {
        let ch = (b'a' + c) as char;
        s.push(ch);
        f(i + if c==i {1} else {0}, n, s, ans);
        s.pop();
    }
}
