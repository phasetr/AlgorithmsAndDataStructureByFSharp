// https://algo-method.com/submissions/725481
fn input() -> String {
    let mut buf = String::new();
    std::io::stdin().read_line(&mut buf).unwrap();
    buf.trim().to_string()
}

fn main() {
    let n: i32 = input().parse().unwrap();
    for _ in 0..n {
        let v: Vec<char> = input().chars().collect();
        print!("{}", v[0]);
    }
}
