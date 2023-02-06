// https://atcoder.jp/contests/tessoku-book/submissions/35022637
use proconio::input;
#[proconio::fastout]
fn main() {
    input!{
        n:i32,
        a:[i32;n],
        q:i32,
        lr:[(usize,usize);q],
    }
    let mut v = vec![0];
    let mut sum = 0;
    for i in a {
        if i == 0 { sum -= 1; }
        else { sum += 1; }
        v.push(sum);
    }
    for (i,j) in lr {
        if v[j] > v[i-1]{ println!("win"); }
        else if v[j] < v[i-1] { println!("lose"); }
        else { println!("draw"); }
    }
}

