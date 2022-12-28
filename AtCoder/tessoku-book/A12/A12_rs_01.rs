// https://atcoder.jp/contests/tessoku-book/submissions/36143840
fn main() {
    proconio::input!{n: usize, k: i64, a: [i64; n]}
    let mut ok = 10_000_000_000;
    let mut err = 0;
    while ok - err > 1 {
        let mid = (ok + err) / 2;
        match a.iter().map(|&v| mid / v).sum::<i64>() >= k {
            true => ok = mid,
            false => err = mid
        }
    }
    println!("{}", ok);
}
