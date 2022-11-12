// https://atcoder.jp/contests/abc133/submissions/16530634
use proconio::{input, fastout};

#[fastout]
fn main() {
    input! {
        n: usize,
        arr: [isize; n],
    }

    let mut x = 0;
    for (i, a) in arr.iter().enumerate() {
        let pa = if i%2==0 { 1 } else { -1 };
        x += pa * a;
    }

    print!("{} ", x);
    for i in 0..n-1 {
        x = -x + 2 * arr[i];
        print!("{} ", x);
    }
}
