// https://atcoder.jp/contests/tessoku-book/submissions/36151995
fn main(){
    proconio::input!{n: usize, mut m: [(usize, usize); n]}
    m.sort_by(|a, b| a.1.cmp(&b.1));
    let mut t = 0;
    let mut r = 0;
    for (s, e) in m {
        if s >= t {
            t = e;
            r += 1;
        }
    }
    println!("{}", r);
}
