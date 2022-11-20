// https://atcoder.jp/contests/abc161/submissions/28295487
use proconio::input;
use itertools::Itertools;
use proconio::marker::Usize1;

fn main() {
    input! {
        k : Usize1
    }

    let mut l : Vec<usize> = (1..10).collect_vec();
    for i in 0..=k {
        if l.len() > k { break }
        if l[i]%10 != 0 { l.push(l[i]*10 + l[i]%10-1); }
        l.push(l[i]*10 + l[i]%10);
        if l[i]%10 != 9 { l.push(l[i]*10 + l[i]%10+1); }
    }

    println!("{}", l[k]);
}
