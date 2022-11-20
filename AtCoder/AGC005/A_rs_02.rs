// https://atcoder.jp/contests/agc005/submissions/9104422
fn main() {
    let mut buf = String::new();
    std::io::stdin().read_line(&mut buf).ok();
    let v: Vec<char> = buf.trim().chars().collect();

    let mut cnt = 0;
    let mut del = 0;
    for &x in v.iter() {
        if x == 'S' {
            cnt += 1;
        } else if cnt > 0 {
            cnt -= 1;
            del += 2;
        }
    }
    println!("{}", v.len() - del);
}
