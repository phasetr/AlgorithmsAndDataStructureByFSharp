// https://atcoder.jp/contests/abc108/submissions/23522230
fn main() {
    proconio::input! { n: i64, k: i64, };
    let modk = n/k;
    let modkhalf = if k % 2 == 0 {n/(k/2)-n/k} else {0};
    let ans = modk.pow(3) + modkhalf.pow(3);
    println!("{}", ans);
}
