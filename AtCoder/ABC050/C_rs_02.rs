// https://atcoder.jp/contests/abc050/submissions/21875188
use proconio::input;

#[allow(non_snake_case)]
fn main() {
    input! { N: usize, mut ds: [i32; N] }
    ds.sort();
    let s = ((N + 1) % 2) as i32;
    if (1..=N as _)
        .into_iter()
        .map(|n| 2 * ((n + s) / 2) - s)
        .collect::<Vec<_>>()
        == ds
    {
        let mut a = 1;
        for _ in 1..=N / 2 {
            a *= 2;
            a %= 1000000007;
        }
        println!("{}", a);
    } else {
        println!("0");
    }
}
