// https://atcoder.jp/contests/tessoku-book/submissions/37093637
fn main() {
    proconio::input!{n: usize, mut a: [usize; n]}
    for i in (0 .. n - 1).rev() {
        for j in 0 ..= i {
            a[j] = match i & 1 == 0 {
                true => a[j].max(a[j + 1]),
                false => a[j].min(a[j + 1])
            }
        }
    }
    println!("{}", a[0]);
}
