// https://atcoder.jp/contests/tessoku-book/submissions/36176675
#[proconio::fastout]
fn main() {
    proconio::input!{n: usize, k: f64, a: [f64; n]}
    let mut l = 1.;
    let mut r = 10f64.powi(9);
    let e = 10f64.powi(-6);
    while r - l > e {
        let mid = (r + l) / 2.;
        match a.iter().map(|&v| (v / mid).floor()).sum::<f64>() >= k {
            true => l = mid,
            false => r = mid
        }
    }
    println!("{}", a.iter().map(|&v| format!("{} ", (v / l).floor())).collect::<String>().trim_end());
}
