// M-x evcxr (evcxr)
use proconio::input;
fn solve(N:i32, X:i32, A:Vec<i32>) -> String {
    match A.iter().any(|&v| v == X) {
        true => "Yes",
        false => "No"
    }.to_string()
}
#[proconio::fastout]
fn main() {
    input! {
        N: i32, X: i32,
        A: [i32; N],
    }
    println!("{}", solve(N,X,A));
}

fn tests() {
    let (N,X,A) = (5,40,vec!(10,20,30,40,50));
    assert_eq!(solve(N,X,A), "Yes");
    let (N,X,A) = (6,28,vec!(30,10,40,10,50,90));
    assert_eq!(solve(N,X,A), "No");
}
