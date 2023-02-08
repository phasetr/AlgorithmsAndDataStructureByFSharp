// https://atcoder.jp/contests/tessoku-book/submissions/36304883
#![allow(clippy::needless_range_loop)]

fn main() {
    proconio::input!{n: usize, p: [(usize, usize, usize, usize); n]}
    let m = 1501;
    let mut g = vec![vec![0; m]; m];
    for (xl, yl, xr, yr) in p {
        g[xl][yl] += 1;
        g[xr][yr] += 1;
        g[xl][yr] -= 1;
        g[xr][yl] -= 1;
    }
    for i in 0 .. m {
        for j in 1 .. m {
            g[i][j] += g[i][j - 1];
        }
    }
    for j in 0 .. m {
        for i in 1 .. m {
            g[i][j] += g[i - 1][j];
        }
    }
    let r = g.iter().map(|gg| gg.iter().filter(|&&v| v > 0).count()).sum::<usize>();
    println!("{}", r);
}
