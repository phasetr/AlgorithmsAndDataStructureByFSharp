// https://atcoder.jp/contests/tessoku-book/submissions/38653323
fn main() {
    proconio::input! {
        n: usize,
        mut p: [(i32, i32); n],
    };
    p.iter_mut().for_each(|a| a.1 *= -1);
    p.sort();
    p.iter_mut().for_each(|a| a.1 *= -1);

    let mut dp = vec![0; n+1];
    let mut min = vec![1<<30; n+1];

    for i in 0..n {
        let j = match min.binary_search(&p[i].1) { Ok(v) => v, Err(v) => v };
        dp[i] = j+1;
        min[j] = min[j].min(p[i].1);
    }

    println!("{}", dp.iter().max().unwrap());
}
