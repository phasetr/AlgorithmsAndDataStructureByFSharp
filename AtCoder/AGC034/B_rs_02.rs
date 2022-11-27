// https://atcoder.jp/contests/agc034/submissions/8385685
fn main() {
    let mut s = String::new();
    std::io::stdin().read_line(&mut s).unwrap();
    let s = s.replace("BC", "D");
    let mut ans = 0u64;
    let mut cnt = 0u64;
    for c in s.chars() {
        if c == 'A' {
            cnt += 1;
        } else if c == 'D' {
            ans += cnt;
        } else {
            cnt = 0;
        }
    }
    println!("{}", ans);
}
