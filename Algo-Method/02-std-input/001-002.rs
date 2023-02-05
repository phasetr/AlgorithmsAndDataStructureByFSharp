fn main() {
    let mut s: String = String::new();
    std::io::stdin().read_line(&mut s).ok();
    let n:i32 = s.trim().parse().unwrap();
    println!("{:?}", n%5);
}
