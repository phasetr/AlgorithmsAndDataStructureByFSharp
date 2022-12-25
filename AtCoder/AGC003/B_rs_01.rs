// https://atcoder.jp/contests/agc003/submissions/31621546
use proconio::input;

fn main() {
    input! {
        n : usize,
        mut a : [usize; n]
    }

    let mut ans = 0;
    for i in 0..n {
        ans += a[i]/2; a[i]%=2;
        if i+1<n { ans += a[i].min(a[i+1]); a[i+1] -= a[i].min(a[i+1]); }
    }

    println!("{}", ans);
}
