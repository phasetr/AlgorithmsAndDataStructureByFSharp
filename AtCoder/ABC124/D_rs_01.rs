// https://atcoder.jp/contests/abc124/submissions/35529171
use proconio::{input, marker::Bytes};

fn main() {
    input! {
        n: usize,
        k: usize,
        s: Bytes,
    }
    let mut v = vec![(1, 0)];
    for i in 0..n {
        let x = (s[i] - b'0') as usize;
        if x != v[v.len() - 1].0 {
            v.push((x, 1));
        } else {
            v.last_mut().unwrap().1 += 1;
        }
    }
    let mut w = 0;
    let mut res = 0;
    let mut s = 0;
    let mut l = 0;
    for i in 0..v.len() {
        if v[i].0 == 0 {
            w += 1;
        }
        s += v[i].1;
        while w > k {
            if v[l].0 == 0 {
                w -= 1;
            }
            s -= v[l].1;
            l += 1;
        }
        res = res.max(s);
    }
    println!("{}", res);
}
