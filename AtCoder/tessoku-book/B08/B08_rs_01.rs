// https://atcoder.jp/contests/tessoku-book/submissions/35782743
use proconio::input;

#[proconio::fastout]
fn main() {
    input! {
        p_size: usize,
        p_xys: [(usize, usize); p_size],
        q_size: usize,
        qs: [(usize, usize, usize, usize); q_size],
    }
    let mut sum = vec![vec![0_u32; 1501]; 1501];
    for (x, y) in p_xys {
        sum[x][y] += 1;
    }
    for y in 1..=1500 {
        for x in 1..=1500 {
            sum[x][y] += sum[x - 1][y];
        }
    }
    for x in 1..=1500 {
        for y in 1..=1500 {
            sum[x][y] += sum[x][y - 1];
        }
    }
    for (lx, by, rx, ty) in qs {
        let ans = sum[rx][ty] - sum[rx][by - 1] - sum[lx - 1][ty] + sum[lx - 1][by - 1];
        println!("{}", ans);
    }
}
