// https://atcoder.jp/contests/tessoku-book/submissions/37103752
use proconio::{input, marker::Chars};

fn solve(h: usize, w: usize, k: usize, cs: &mut Vec<Vec<char>>) -> usize {
    let mut wr: Vec<usize> = vec![0; h];
    let mut wc: Vec<usize> = vec![0; w];
    let mut res = 0;
    for r in 0..h {
        for c in 0..w {
            if cs[r][c] == '.' {
                wr[r] += 1;
                wc[c] += 1;
            }
            else {
                res += 1;
            }
        }
    }

    wr.sort_by(|a, b| b.cmp(&a));
    wc.sort_by(|a, b| b.cmp(&a));

    let mut cr = 0;
    let mut cc = 0;
    for i in 0..k {
        cr += wr[i];
        cc += wc[i];
    }
    res += std::cmp::max(cc, cr);

    res
}

fn main() {
    input!{
        h: usize, w: usize, k: usize,
        mut cs: [Chars; h],
    };
    println!("{}", solve(h, w, k, &mut cs));
}
