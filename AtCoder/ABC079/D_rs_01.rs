// https://atcoder.jp/contests/abc079/submissions/27895181
use proconio::input;

fn main() {
    input! {
        h: usize, w: usize,
        mut c: [[i32; 10]; 10],
        a: [[i32; w]; h],
    }
    for k in 0..=9 {
        for i in 0..=9 {
            for j in 0..=9 {
                c[i][j] = c[i][j].min(c[i][k]+c[k][j]);
            }
        }
    }
    let mut ans = 0;
    for i in 0..h {
        for j in 0..w {
            if a[i][j] != -1 {
                ans += c[a[i][j] as usize][1];
            }
        }
    }
    println!("{}", ans);
}
