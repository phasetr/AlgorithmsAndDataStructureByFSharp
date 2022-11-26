// https://atcoder.jp/contests/diverta2019/submissions/7158470
fn main() {
    let mut s = String::new();
    std::io::stdin().read_line(&mut s).unwrap();
    let n: u64 = s.trim().parse().unwrap();
    let mut ans = 0;
    let mut a = 1;
    while a * a + a < n {
        if (n - a) % a == 0 {
            ans += (n - a) / a;
        }
        a += 1;
    }
    println!("{}", ans);
}
