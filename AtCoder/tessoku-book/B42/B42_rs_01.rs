// https://atcoder.jp/contests/tessoku-book/submissions/35462090
use proconio::input;

fn main() {
    input! {
        n: usize,
        ab: [(i64, i64); n],
    }
    let mut res = 0;
    for &x in &[1, -1] {
        for &y in &[1, -1] {
            let mut sa = 0;
            let mut sb = 0;
            for &(a, b) in &ab {
                if a * x + b * y >= 0 {
                    sa += a;
                    sb += b;
                }
            }
            res = res.max(sa.abs() + sb.abs());
        }
    }
    println!("{}", res);
}
