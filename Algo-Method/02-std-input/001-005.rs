// https://algo-method.com/submissions/276393
fn main() {
    let mut s = String::new();
    std::io::stdin().read_line(&mut s);
    let num :u32 = s.trim().parse().unwrap();
    println!("{}", 24 - num);
}
