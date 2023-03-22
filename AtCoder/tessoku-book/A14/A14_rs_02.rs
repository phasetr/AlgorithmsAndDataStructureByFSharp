// https://atcoder.jp/contests/tessoku-book/submissions/35918722
use std::collections::HashSet;
use proconio::input;

#[proconio::fastout]
fn main() {
    input! {
        n: usize, k: i32,
        a: [i32; n],
        b: [i32; n],
        c: [i32; n],
        d: [i32; n],
    }
    let mut set: HashSet<i32> = HashSet::new();
    for &x in a.iter() {
        for &y in b.iter() {
            set.insert(x+y);
        }
    }
    for &x in c.iter() {
        for &y in d.iter() {
            if set.contains(&(k-x-y)) {
                println!("Yes");
                return;
            }
        }
    }
    println!("No");
}
