// https://atcoder.jp/contests/tessoku-book/submissions/36154777
fn main() {
    proconio::input!{q: usize, x: [usize; q]}
    let n = *x.iter().max().unwrap();
    let mut p = vec![true; n + 1];
    for i in 2 .. n {
        if p[i] {
            (2 ..= n / i).for_each(|j| p[i * j] = false);
        }
    }
    let r = x.iter().map(|&v| format!("{}\n", if p[v] {"Yes"} else {"No"})).collect::<String>();
    print!("{}", r);
}
