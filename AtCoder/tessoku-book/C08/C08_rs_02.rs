// https://atcoder.jp/contests/tessoku-book/submissions/36733815
#[proconio::fastout]
fn main() {
    proconio::input!{n: usize, t: [(usize, usize); n]}
    let mut r = None;
    for i in 0 .. 10000 {
        if t.iter().all(|&(x, k)| {
            let s = match (0 .. 4).filter(|&j| i / 10usize.pow(j) % 10 != x / 10usize.pow(j) % 10).count() {
                0 => 1,
                1 => 2,
                _ => 3
            };
            s == k
        }) {
            match r {
                None => r = Some(i),
                Some(_) => {println!("Can't Solve"); return;}
            }
        }
    }
    println!("{:04}", r.unwrap());
}
