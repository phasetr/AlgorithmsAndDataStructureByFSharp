// https://atcoder.jp/contests/abc050/submissions/23682194
use itertools::Itertools;

fn main() {
    proconio::input! { n: usize, mut a: [usize; n], };
    a.sort();
    let mut a0 = vec![];
    for i in (0..n).rev() { a0.push(n-1-i/2*2); }
    if a != a0 {
        println!("0");
        return;
    }
    let mut ans = 1;
    for _ in 0..n/2 {
        ans = ans * 2 % 1_000_000_007;
    }
    println!("{}", ans);
}
