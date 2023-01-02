// https://atcoder.jp/contests/tessoku-book/submissions/35237988
use proconio::input;

fn main() {
    input! {
        n: usize,
        a: usize,
        b: usize,
    };

    let min = a.min(b);

    let x = (n - a) % (a + b);
    let y = (n - b) % (a + b);

    if x < min || y < min {
        println!("First");
    } else {
        println!("Second");
    }
}
