// https://atcoder.jp/contests/tessoku-book/submissions/36362154
use proconio::{input, marker::Usize1};

// 貪欲法
fn f1(pqr: &[(usize, usize, usize)]) -> Vec<char> {
    let mut x = vec![0_i64; 20];
    let score = |x: &[i64]| -> usize { x.iter().filter(|a_i| a_i == &&0).count() };
    let a = |x: &mut Vec<i64>, p: usize, q: usize, r: usize| {
        x[p] += 1;
        x[q] += 1;
        x[r] += 1;
    };
    let b = |x: &mut Vec<i64>, p: usize, q: usize, r: usize| {
        x[p] -= 1;
        x[q] -= 1;
        x[r] -= 1;
    };
    let mut ret = vec![];
    for (p, q, r) in pqr.iter().copied() {
        a(&mut x, p, q, r);
        let score_a = score(&x);
        b(&mut x, p, q, r);
        b(&mut x, p, q, r);
        let score_b = score(&x);
        a(&mut x, p, q, r);
        if score_a > score_b {
            a(&mut x, p, q, r);
            ret.push('A');
        } else {
            b(&mut x, p, q, r);
            ret.push('B');
        }
    }
    ret
}

fn main() {
    input! {
        t: usize,
        pqr: [(Usize1, Usize1, Usize1); t],
    };
    let ans = f1(&pqr);
    for a in ans {
        println!("{}", a);
    }
}
