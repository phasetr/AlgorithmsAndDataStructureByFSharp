// https://atcoder.jp/contests/tessoku-book/submissions/36292804
fn main() {
    proconio::input!{
        n: usize,
        mut a_s: [i32; n]
    };

    a_s.sort();
    println!("{}", a_s[n - 2] + a_s[n - 1]);
}
