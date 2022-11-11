// https://atcoder.jp/contests/abc052/submissions/35964805
use std::collections::HashMap;

use proconio::input;

fn main() {
    input! {
        n:u64
    }
    let md: u64 = 1_000_000_000 + 7;
    let mut hm: HashMap<u64, u64> = HashMap::new();
    let mut cnt: u64 = 1;

    for i in 2..=n {
        let mut tmp: u64 = i;
        for j in 2..=n {
            while tmp % j == 0 {
                *hm.entry(j).or_insert(1) += 1;
                tmp = tmp / j;
            }
        }
    }

    for (k, v) in hm.iter() {
        cnt = cnt * v % md;
    }
    println!("{}", cnt);
}
