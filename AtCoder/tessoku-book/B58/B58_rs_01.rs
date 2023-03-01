// https://atcoder.jp/contests/tessoku-book/submissions/36861884
use std::ops::RangeInclusive;

fn main() {
    proconio::input!{n: usize, l: u64, r: u64, a: [u64; n]}
    let range = l ..= r;
    let mut min = None;
    dfs(&a, &range, &mut min, 0, 0);
    println!("{}", min.unwrap());
}

fn dfs(a: &[u64], range: &RangeInclusive<u64>, min: &mut Option<u64>, t: usize, count: u64) {
    let count = count + 1;
    let max = a.binary_search(&(a[t] + range.end())).unwrap_or_else(|v| v - 1);
    if max == a.len() - 1 {
        *min = Some(count);
    }
    for i in (t + 1 ..= max).rev() {
        if min.is_some() || !range.contains(&(a[i] - a[t])) {break;}
        dfs(a, range, min, i, count);
    }
}

