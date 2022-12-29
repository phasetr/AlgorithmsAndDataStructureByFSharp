// https://atcoder.jp/contests/tessoku-book/submissions/35918900
use proconio::input;

fn main() {
    input! {
        n: usize,
        mut a: [i32; n],
    }
    let b = a.clone();
    a.sort();
    a.dedup();
    for x in b.iter() {
        print!("{} ",a.binary_search(x).unwrap()+1);
    }
    println!("");
}
