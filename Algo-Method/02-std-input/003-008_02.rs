// https://algo-method.com/submissions/722924
fn input() -> String {
    let mut t = String::new();
    std::io::stdin().read_line(&mut t).unwrap();
    t.trim().to_string()
}

fn main() {
    let n: i32 = input().parse().unwrap();
    let mut a = 0;
    for _ in 0..n {
        a += input().len();
    }
    println!("{}", a);
}

