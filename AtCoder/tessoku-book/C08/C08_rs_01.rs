// https://atcoder.jp/contests/tessoku-book/submissions/37668511
use itertools::iproduct;
use itertools::Itertools;
use proconio::{input, marker::Chars};
#[proconio::fastout]
fn main() {
    input! {
        n:usize,
        stn:[(Chars,usize);n],
    }
    let mut ans = vec![];
    for i in iproduct!(0..=9, 0..=9, 0..=9, 0..=9) {
        let p = [i.0, i.1, i.2, i.3];
        let mut f = true;
        for (s, t) in &stn {
            let mut cnt = 1;
            for k in 0..4 {
                if s[k] as usize - '0' as usize != p[k] {
                    cnt += 1;
                }
            }
            if cnt > 3 {
                cnt = 3;
            }
            if cnt != *t {
                f = false;
                break;
            }
        }
        if f {
            ans.push(p);
        }
    }
    if ans.len() == 1 {
        println!("{}", ans[0].iter().join(""));
    } else {
        println!("Can't Solve");
    }
}
