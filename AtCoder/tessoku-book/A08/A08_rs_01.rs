// https://atcoder.jp/contests/tessoku-book/submissions/35027561
use proconio::input;
#[proconio::fastout]
fn main() {
    input!{
        h:usize,w:usize,
        x:[[i32;w];h],
        q:i32,
        abcd:[(usize,usize,usize,usize);q],
    }
    let mut sum = vec![vec![0;w+1];h+1];
    for i in 0..h{
        for j in 0..w{
            sum[i+1][j+1] = sum[i+1][j] + x[i][j];
        }
    }
    for i in 0..h{
        for j in 0..w{
            sum[i+1][j+1] += sum[i][j+1];
        }
    }
    for (a,b,c,d) in abcd{
        println!("{}",sum[c][d]-sum[c][b-1]-sum[a-1][d]+sum[a-1][b-1]);
    }
}
