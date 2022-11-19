// https://atcoder.jp/contests/abc147/submissions/22059314
use proconio::{input, marker::Usize1};

fn main() {
    input! { n: usize, xy: [[(Usize1, usize)]; n]}
    let mut ans = 0;
    for i in 0..(1usize<<n) {
        let mut flag = true;
        for j in 0..n {
            if (i >> j) & 1 == 0 { continue; }
            for (x, y) in &xy[j] {
                if (i >> x) & 1 != *y {
                    flag = false;
                }
            }
        }
        if flag { ans = ans.max(i.count_ones()); }
    }
    println!("{}", ans);
}
