// https://atcoder.jp/contests/diverta2019-2/submissions/30592747
use std::collections::HashMap;
use proconio::{input};

fn main() {
    input!{n:usize,mut xyn:[(i64,i64);n]}

    xyn.sort();
    let mut count_map= HashMap::new();
    for i in 0..n{
        for j in i+1..n{
            *count_map.entry((xyn[j].0-xyn[i].0,xyn[j].1-xyn[i].1)).or_insert(0) += 1;
        }
    }

    println!("{}",n-count_map.values().max().unwrap_or(&0));
}
