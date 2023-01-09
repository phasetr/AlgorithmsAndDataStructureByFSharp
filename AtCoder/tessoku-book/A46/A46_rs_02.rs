// https://atcoder.jp/contests/tessoku-book/submissions/35986625
use proconio::{input, fastout};
use proconio::marker::{Bytes, Chars, Usize1};

#[fastout]
fn main() {
    input!{
        n: usize,
        p: [(f64, f64); n],
    }
    let mut ans = vec![1];
    let mut seen = vec![false; n];
    seen[0] = true;
    let mut cnt = 1;

    let (mut x, mut y) = p[0];
    while cnt < n {
        let mut min_dist = 1_000_000_000f64;
        let mut nv = 0;
        for (i, &(nx, ny)) in p.iter().enumerate() {
            if seen[i] { continue; }
            let dist = (x-nx).hypot(y-ny);
            if dist < min_dist {
                nv = i;
                min_dist = dist;
            }
        }
        cnt += 1;
        seen[nv] = true;
        ans.push(nv+1);
        x = p[nv].0; y = p[nv].1;
    }
    ans.push(1);

    for x in ans {
        println!("{}", x);
    }
}
