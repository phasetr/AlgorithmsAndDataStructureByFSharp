// https://atcoder.jp/contests/abc109/submissions/28098361
use proconio::{input, fastout};

#[fastout]
fn main() {
    input!{
        h: usize, w: usize,
        mut a: [[usize; w]; h],
    }

    let mut ans = vec![];

    for i in 0..h {
        for j in (1..w).rev() {
            if a[i][j] % 2 == 1 {
                a[i][j] -= 1;
                a[i][j-1] += 1;
                ans.push((i, j, i, j-1));
            }
        }
    }
    for i in (1..h).rev() {
        if a[i][0] % 2 == 1 {
            a[i][0] -= 1;
            a[i-1][0] += 1;
            ans.push((i, 0, i-1, 0));
        }
    }

    println!("{}", ans.len());
    for (a, b, c, d) in ans {
        println!("{} {} {} {}", a+1, b+1, c+1, d+1);
    }
}
