// https://atcoder.jp/contests/arc058/submissions/14687491
fn main() {
    proconio::input!(n: u32, d: [usize]);
    let ok = d.iter().fold(vec![true; 10], |mut ok, &d| {
        ok[d] = false;
        ok
    });
    let ans = (n..)
        .find(|n| n.to_string().bytes().all(|b| ok[(b - b'0') as usize]))
        .unwrap();
    println!("{}", ans);
}
