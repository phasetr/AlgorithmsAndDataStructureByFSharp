// https://atcoder.jp/contests/abc112/submissions/24774315
use proconio::input;

fn main() {
    input! {
        n: i64,
        m: i64,
    }
    let mut ans = 1;
    for i in 1..100000 {
        if m%i == 0 {
            if n*i <= m && ans < i {
                ans = i;
            }
            if n*(m/i) <= m && ans < (m/i) {
                ans = m/i;
            }
        }
    }
    println!("{}", ans);
}
