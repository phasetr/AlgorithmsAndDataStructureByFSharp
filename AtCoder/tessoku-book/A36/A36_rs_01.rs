// https://atcoder.jp/contests/tessoku-book/submissions/37053
use proconio::input;

fn main() {
    input!{
        n: usize,
        k: usize,
    }
    println!("{}", if k >= 2 * n - 2 && k % 2 == 0{"Yes"} else {"No"});
}
