// https://atcoder.jp/contests/nikkei2019-qual/submissions/22971643
use proconio::input;
use itertools::Itertools;

fn main() {
    input! {
        n : usize,
        mut ab : [(i64, i64); n]
    }

    ab.sort_by_key(|&(a,b)| (-(a+b), a, b));

    let mut ans = 0;
    for i in 0..n {
        ans += if i%2==0 {ab[i].0} else {-ab[i].1}
    }

    println!("{}", ans);
}
