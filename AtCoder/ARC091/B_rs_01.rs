// https://atcoder.jp/contests/abc090/submissions/36740575
use proconio::{*};

fn main() {
    input! {
        n: i64,
        k: i64,
    }

    let mut ans = 0i64;
    for b in k+1..=n {
        ans += n/b * (b - k);
        ans += (n%b - k + 1).max(0);
    }

    if k == 0 {
        ans -= n;
    }

    println!("{}", ans);
}
