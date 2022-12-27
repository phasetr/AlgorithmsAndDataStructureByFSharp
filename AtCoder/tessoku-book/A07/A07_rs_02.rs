// https://atcoder.jp/contests/tessoku-book/submissions/37435393
use proconio::input;

fn main() {
    input!{
        d: usize,
        n: usize,
        lr: [(usize, usize); n],
    }

    let mut sum = vec![0; d+1];
    for (l, r) in lr {
        for i in l..=r {
            sum[i] += 1;
        }
    }

    for i in 1..=d {
        println!("{}", sum[i]);
    }
}
