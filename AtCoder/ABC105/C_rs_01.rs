// https://atcoder.jp/contests/abc105/submissions/25797785
fn main() {
    proconio::input! { n: i32 }
    let mut v = 0;
    let mut b = 1;
    let mut m = 1;
    let mut a = 0;
    while v != n {
        if n & m != v & m {
            a |= m;
            v += b;
        }
        b *= -2;
        m <<= 1;
    }
    println!("{:b}", a);
}
