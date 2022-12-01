// https://atcoder.jp/contests/tenka1-2018/submissions/24534182
use std::iter::repeat;

#[allow(unused_imports)]
#[cfg(feature = "dbg")]
use dbg::lg;
use proconio::{fastout, input};

#[fastout]
fn main() {
    input! { n: usize, mut a: [i64; n] }
    a.sort();
    let mut ans = 0;
    for b in match n % 2 {
        0 => vec![vec![n / 2 - 1, 1, 0, 1, n / 2 - 1]],
        1 => vec![
            vec![n / 2 - 1, 2, 0, 0, n / 2],
            vec![n / 2, 0, 0, 2, n / 2 - 1],
        ],
        _ => unreachable!(),
    } {
        ans = ans.max(
            b.iter()
                .zip(-2..=2)
                .flat_map(|(&count, coeff)| repeat(coeff).take(count))
                .zip(&a)
                .map(|(coeff, &x)| coeff * x)
                .sum::<i64>(),
        );
    }
    println!("{}", ans);
}

// template {{{
#[cfg(not(feature = "dbg"))]
#[allow(unused_macros)]
#[macro_export]
macro_rules! lg {
    ($($expr:expr),*) => {};
}
// }}}
