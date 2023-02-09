// https://atcoder.jp/contests/tessoku-book/submissions/36304434
fn main() {
    proconio::input!{n: f64}
    let mut l = 0.;
    let mut r = n.sqrt();
    while r - l >= 0.001 {
        let m = (l + r) / 2.;
        match m * m * m + m >= n {
            true => r = m,
            false => l = m
        }
    }
    println!("{}", r);
}
