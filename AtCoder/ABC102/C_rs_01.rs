// https://atcoder.jp/contests/abc102/submissions/22702804
use proconio::input;
fn main() {
    input!{
        n: usize,
        mut va: [i64;n]
    };
    for i in 0..n {
        va[i] -= i as i64;
    }
    va.sort();
    let mut ans = 0;
    for i in 0..(n/2) {
        ans += va[n-i-1] - va[i];
    }
    println!("{}",ans);

}
