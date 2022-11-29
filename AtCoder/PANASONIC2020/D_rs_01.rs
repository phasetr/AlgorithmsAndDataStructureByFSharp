// https://atcoder.jp/contests/panasonic2020/submissions/30835624
use proconio::{input};

fn main() {
    input! {n:usize}
    let mut p:Vec<char> = vec![];
    dfs(n,&mut p,'a' as u8-1);
}

fn dfs(n:usize,s:&mut Vec<char>,mx:u8){
    if s.len() >= n{
        println!("{}",s.iter().collect::<String>());
        return;
    }
    for c in 'a' as u8..=mx+1{
        s.push(c as char);
        dfs(n,s,mx.max(c));
        s.pop();
    }
}
