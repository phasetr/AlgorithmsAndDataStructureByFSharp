// https://atcoder.jp/contests/tessoku-book/submissions/36323155
fn main() {
    proconio::input!{n: usize, m: usize, e: [(usize, usize); m]}
    let mut g = vec![0; n + 1];
    e.iter().for_each(|&(a, b)| {g[a] += 1; g[b] += 1});
    println!("{}", g.iter().enumerate().max_by(|&a, &b| a.1.cmp(b.1)).unwrap().0);
}
