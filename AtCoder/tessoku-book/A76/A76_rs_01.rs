// https://atcoder.jp/contests/tessoku-book/submissions/38031022
use proconio::input;

fn main() {
    input! {
        n: usize,
        w: usize,
        l: usize,
        r: usize,
        mut x: [usize; n],
    }

    const MOD: usize = 1_000_000_007;

    let n = n + 2;
    x.insert(0, 0);
    x.push(w);

    let mut imos = vec![0; n + 1];
    imos[0] = 1;
    imos[1] = MOD - 1;

    let mut cur = 0;
    let mut j = 0;
    let mut k = 0;
    for i in 0..n {
        cur = (cur + imos[i]) % MOD;
        while j < n && x[j] - x[i] < l {
            j += 1;
        }
        while k < n && x[k] - x[i] <= r {
            k += 1;
        }
        imos[j] = (imos[j] + cur) % MOD;
        imos[k] = (imos[k] + MOD - cur) % MOD;
    }

    println!("{}", cur);
}
