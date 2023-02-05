// https://atcoder.jp/contests/tessoku-book/submissions/37094021
fn main() {
    proconio::input!{n: usize, p: [[usize; n]; n]}
    let mut x = vec![0; n];
    let mut y = x.clone();
    for i in 0 .. n {
        for j in 0 .. n {
            if p[i][j] > 0 {
                let e = p[i][j];
                x[j] = e;
                y[i] = e;
            }
        }
    }
    let mut c = 0;
    for i in 0 .. n - 1 {
        for j in i + 1 .. n {
            if x[i] > x[j] { c += 1; }
            if y[i] > y[j] { c += 1; }
        }
    }
    println!("{}", c);
}
