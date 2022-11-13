// https://atcoder.jp/contests/abc085/submissions/16971492
fn main() {
    proconio::input! {
        n: usize,
        mut h: i32,
        ab: [(i32,i32);n],
    }
    let m = ab.iter().max_by_key(|ab| ab.0).unwrap().0;
    let mut t: Vec<i32> = ab.iter().map(|ab| ab.1).filter(|&b| b > m).collect();
    t.sort_unstable();
    let mut k = 0;
    while let Some(b) = t.pop() {
        k += 1;
        h -= b;
        if h <= 0 {
            break;
        }
    }
    if h > 0 {
        k += (h + m - 1) / m;
    }
    println!("{}", k);
}
