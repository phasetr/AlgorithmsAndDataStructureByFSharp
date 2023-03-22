// https://atcoder.jp/contests/tessoku-book/submissions/35984291
use proconio::input;
use rustc_hash::FxHashSet;

#[proconio::fastout]
fn main() {
    input! {
        n: usize,
        k: i32,
        mut av: [i32; n],
        mut bv: [i32; n],
        mut cv: [i32; n],
        mut dv: [i32; n],
    }
    let mut cd = FxHashSet::default();
    for c in &cv {
        for d in &dv {
            if c + d < k {
                cd.insert(c + d);
            }
        }
    }
    for a in &av {
        for b in &bv {
            if a + b < k && cd.contains(&(k - a - b)) {
                println!("{}", "Yes");
                return;
            }
        }
    }
    println!("{}", "No");
}
