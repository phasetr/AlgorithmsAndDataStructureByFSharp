// https://atcoder.jp/contests/tessoku-book/submissions/35765082
use itertools::Itertools;
use proconio::input;
use superslice::Ext;

#[allow(non_snake_case)]
fn main() {
    input! {
        n: usize,
        mut A: [usize; n]
    }

    let mut B = A.clone();
    B.sort();
    B.dedup();

    let mut ans = vec![0; n];

    for (i, a) in A.iter().enumerate() {
        ans[i] = B.lower_bound(a) + 1;
    }

    println!("{}", ans.iter().join(" "));
}
