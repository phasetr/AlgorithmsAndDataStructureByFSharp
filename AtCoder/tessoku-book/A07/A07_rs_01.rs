// https://atcoder.jp/contests/tessoku-book/submissions/36116587
use proconio::{marker::Usize1, input, fastout};

#[fastout]
fn main()
{
    input!{d: usize, n: usize, q: [(Usize1, Usize1); n]}
    let mut v = vec![0; d];
    q.iter().for_each(|&(l, r)| {v[l] += 1; if r < d - 1{v[r + 1] -= 1}});
    (1 .. d).for_each(|i| v[i] += v[i - 1]);
    for c in v {
        println!("{}", c);
    }
}
