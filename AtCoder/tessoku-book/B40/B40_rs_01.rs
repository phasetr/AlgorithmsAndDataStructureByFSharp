// https://atcoder.jp/contests/tessoku-book/submissions/36715158
fn main() {
    proconio::input!{n: usize, a: [usize; n]}
    let mut c = vec![0; 100];
    let mut r = 0;
    for v in a {
        let i = v % 100;
        r += c[(100 - i) % 100];
        c[i] += 1;
    }
    println!("{}", r);
}

