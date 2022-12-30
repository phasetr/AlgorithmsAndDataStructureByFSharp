// https://atcoder.jp/contests/tessoku-book/submissions/35083872
use proconio::input;
#[proconio::fastout]
fn main() {
    input!{
        n:usize,
        a:[i32;n-1],
        b:[i32;n-2],
    }
    let mut v = vec![0,a[0]];
    for i in 2..n{
        v.push((v[i-1]+a[i-1]).min(v[i-2]+b[i-2]));
    }
    println!("{}",v[v.len()-1]);
}
