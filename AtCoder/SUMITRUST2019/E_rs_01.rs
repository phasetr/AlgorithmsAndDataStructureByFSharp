// https://atcoder.jp/contests/sumitrust2019/submissions/27762478
fn main() {
    proconio::input! {
        n: usize,
        a: [u32; n],
    }
    const MOD: usize = 1_000_000_007;
    let mut ans = 1;
    let mut cnt = [0; 3];
    for a in a {
        ans = ans * cnt.iter().filter(|c| **c == a).count() % MOD;
        cnt.iter_mut().find(|c| **c == a).map(|c| *c += 1);
    }
    println!("{}", ans);
}
