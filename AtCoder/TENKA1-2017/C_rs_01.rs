// https://atcoder.jp/contests/tenka1-2017/submissions/30805736
use proconio::input;
fn main() {
    input! {N:usize}
    for h in 1..=3500{
        for n in 1..=3500{
            if 4*h*n <= N*(n+h){
                continue;
            }
            if (h*n*N) % (4*h*n-N*(n+h)) == 0{
                println!("{} {} {}",h,n,(h*n*N) / (4*h*n-N*(n+h)));
                return;
            }
        }
    }
}
