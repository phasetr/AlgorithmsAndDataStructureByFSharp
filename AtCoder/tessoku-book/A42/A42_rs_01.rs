// https://atcoder.jp/contests/tessoku-book/submissions/35948266
use proconio::input;
const MAX: usize = 100;

fn main() {
    input! {
        n: usize, k: usize,
        students: [(usize, usize); n],
    }
    let mut ans = 0;
    for i in 0..=MAX {
        for j in 0..=MAX {
            let mut res = 0;
            for &(a, b) in students.iter() {
                if i <= a && a <= i+k && j <= b && b <= j+k {
                    res += 1;
                }
            }
            ans = ans.max(res);
        }
    }
    println!("{}",ans);
}
