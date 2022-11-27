// https://atcoder.jp/contests/abc129/submissions/35742253
use proconio::{input, marker::Bytes};
use superslice::Ext;

fn main() {
    input! { h: usize, w: usize, s: [Bytes; h] }

    let mut h_blk = vec![vec![-1]; h];
    let mut w_blk = vec![vec![-1]; w];
    for i in 0..h {
        for j in 0..w {
            if s[i][j] == b'#' {
                h_blk[i].push(j as i32);
                w_blk[j].push(i as i32);
            }
        }
    }
    for i in 0..h {
        h_blk[i].push(w as i32);
    }
    for i in 0..w {
        w_blk[i].push(h as i32);
    }
    let mut ans = 0;
    for i in 0..h {
        for j in 0..w {
            let j_lb = h_blk[i].lower_bound(&(j as i32)) - 1;
            let i_lb = w_blk[j].lower_bound(&(i as i32)) - 1;
            let sum = h_blk[i][j_lb + 1] - h_blk[i][j_lb] + w_blk[j][i_lb + 1] - w_blk[j][i_lb] - 3;
            ans = ans.max(sum);
        }
    }
    println!("{}", ans);
}
