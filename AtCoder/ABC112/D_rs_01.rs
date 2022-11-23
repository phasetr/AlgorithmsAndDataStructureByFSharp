// https://atcoder.jp/contests/abc112/submissions/28109007
use proconio::input;

fn main() {
    input!{
        n: usize,
        m: usize,
    }

    for i in (1..=m/n).rev() {
        if m % i != 0 { continue; }
        println!("{}", i);
        break;
    }
}
