// https://atcoder.jp/contests/abc161/submissions/13202248
use std::collections::VecDeque;
fn main() {
    proconio::input! {
        k: usize,
    }
    let mut q:VecDeque<u64> = [1,2,3,4,5,6,7,8,9].iter().map(|&x| x).collect();
    for _ in 0..(k-1) {
        let x = q.remove(0).unwrap();
        if x % 10 != 0 { q.push_back(10*x + (x%10)-1); }
        q.push_back(10*x + (x%10));
        if x % 10 != 9 { q.push_back(10*x + (x%10)+1); }
    }
    println!("{}", q.get(0).unwrap());
}
