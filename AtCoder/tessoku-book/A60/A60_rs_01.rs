// https://atcoder.jp/contests/tessoku-book/submissions/37998528
use proconio::input;

fn main() {
    input! {
        n: usize,
        a: [usize; n],
    }

    let mut stoke: Vec<(usize, usize)> = vec![];
    for i in 0..n {
        while !stoke.is_empty() {
            let (mut k, mut v) = stoke.last().unwrap();
            if a[i] < v {
                print!("{}", k + 1);
                break;
            } else {
                stoke.pop();
            }
        }
        if stoke.is_empty() {
            print!("-1");
        }
        stoke.push((i, a[i]));
        print!(" ")
    }
    println!("");
}
