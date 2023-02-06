// https://atcoder.jp/contests/tessoku-book/submissions/36302086
#[proconio::fastout]
fn main() {
    proconio::input!{t: usize, n: usize, q: [(usize, usize); n]}
    let mut s = vec![0; t + 1];
    q.iter().for_each(|&(l, r)| {s[l] += 1; s[r] -= 1});
    (1 ..= t).for_each(|i| s[i] += s[i - 1]);
    s.pop();
    print!("{}", s.iter().map(|&v| format!("{}\n", v)).collect::<String>());
}
