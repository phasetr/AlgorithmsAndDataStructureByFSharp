// https://atcoder.jp/contests/abc147/submissions/22458708
use proconio::input;
use std::cmp::max;

fn main() {
    input!{n:i8,axy:[[(usize,i64)];n]}
    println!("{}",(1..1<<n)
             .filter(|i| axy.iter().enumerate().all(|(j,xy)|
                                                    xy.iter().all(|(num,v)|((i & (1 << j)) == 0) || ((i & (1 << (num-1))) > 0) as i64 == *v)
             ))
             .fold(0,|ans,i| max(ans,(0..n).filter(|x| (i & (1 << x)) != 0).count())));
}
