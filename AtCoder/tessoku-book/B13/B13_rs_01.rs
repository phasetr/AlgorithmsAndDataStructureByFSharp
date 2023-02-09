// https://atcoder.jp/contests/tessoku-book/submissions/36304668
fn main() {
    proconio::input!{n: usize, k: u64, mut a: [u64; n]}
    let mut p = 0;
    let mut t = 0;
    let mut c = 0;
    for i in 0 .. n {
        while p < n && t + a[p] <= k {
            t += a[p];
            p += 1;
        }
        t -= a[i];
        c += p - i;
    }
    println!("{}", c);
}
