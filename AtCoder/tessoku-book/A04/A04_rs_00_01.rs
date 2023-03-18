use proconio::input;
fn solve(n:i32) -> String {
    format!("{:010b}", n)
}
#[proconio::fastout]
fn main() {
    input! {
        n: i32
    }
    println!("{}", solve(n));
}

fn tests() {
    let n = 13;
    assert_eq!(solve(n), "0000001101");
    let n = 37;
    assert_eq!(solve(n), "0000100101");
    let n = 1000;
    assert_eq!(solve(n), "1111101000");
}
