//https://atcoder.jp/contests/tessoku-book/submissions/37770745
use std::collections::VecDeque;

use num_integer::Roots;
use proconio::input;

fn main() {
    input! {
        n: usize,
    }
    let mut queue = VecDeque::new();
    let sqrt = n.sqrt();
    for i in 1..=sqrt {
        if n % i == 0 {
            println!("{}", i);
            queue.push_front(n / i);
        }
    }
    for &x in &queue {
        println!("{}", x);
    }
}

