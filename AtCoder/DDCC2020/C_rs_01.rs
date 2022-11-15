// https://atcoder.jp/contests/ddcc2020-qual/submissions/14688699
use itertools::Itertools;
use proconio::{input, marker::Chars};

fn main() {
    input!(h: usize, _w: usize, _k: usize, s: [Chars; h]);
    let ans = s.iter().scan(0, |cnt, row| {
        if let Some(p) = row.iter().position(|&c| c == '#') {
            let res = row
                .iter()
                .enumerate()
                .map(|(i, &c)| {
                    *cnt += (c == '#') as usize;
                    (*cnt + (i < p) as usize).to_string()
                })
                .collect_vec()
                .join(" ");
            Some(Some(res))
        } else {
            Some(None)
        }
    });
    let first_some = ans.clone().find(|it| it.is_some()).unwrap();
    let ans = ans
        .scan(first_some, |pre, it| {
            *pre = it.or(pre.clone());
            Some(pre.clone().unwrap())
        })
        .collect_vec()
        .join("\n");
    println!("{}", ans);
}
