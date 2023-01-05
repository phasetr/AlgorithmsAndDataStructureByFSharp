// https://atcoder.jp/contests/tessoku-book/submissions/36840758
use proconio::input;

#[allow(non_snake_case)]
fn main() {
    input! {
        N:usize,
        K:usize,
        AB:[(usize,usize);N]
    }
    let mut ans = 0;
    for a_low in 1..=100 {
        for b_low in 1..=100 {
            let mut cnt = 0;
            for (a, b) in &AB {
                if *a >= a_low && *a <= a_low + K && *b >= b_low && *b <= b_low + K {
                    cnt += 1;
                }
            }
            ans = ans.max(cnt);
        }
    }
    println!("{}", ans);
}
