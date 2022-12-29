// https://atcoder.jp/contests/tessoku-book/submissions/35918371
use proconio::input;
use superslice::Ext;

fn main() {
    input! {
        n: usize, k: i32,
        mut a: [i32; n],
    }
    a.sort();
    let mut ans: i64 = 0;
    for l in 0..n {
        let r = a.upper_bound(&(a[l]+k));
        ans += (r-l-1) as i64;
    }
    println!("{}",ans);
}
