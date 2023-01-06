// https://atcoder.jp/contests/tessoku-book/submissions/35597472
use proconio::{input, marker::Usize1};
#[proconio::fastout]
fn main() {
    input!{
        n:usize,q:i32,
    }
    let mut a:Vec<usize> = (1..=n).collect();
    let mut rev_flag = false;
    for _ in 0..q{
        input!{
            que:i32,
        }
        if que == 1{
            input!{x:Usize1,y:usize,}
            a[if !rev_flag{x}else{n-1-x}] = y;
        }else if que == 2{
            rev_flag = !rev_flag;
        }else{
            input!{x:Usize1}
            println!("{}",a[if !rev_flag{x}else{n-1-x}]);
        }
    }
}
