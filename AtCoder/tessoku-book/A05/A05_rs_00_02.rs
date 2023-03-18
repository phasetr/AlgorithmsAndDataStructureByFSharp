use proconio::input;
fn solve(n:i32,k:i32) -> usize {
    (1..=n)
        .map(|i|
             (1..=n)
             .filter(|j| {let x = k-i-j; 1<=x && x<=n})
             .count())
        .sum::<usize>()
}
#[proconio::fastout]
fn main() {
    input! {
        n: i32,
        k: i32
    }
    println!("{}", solve(n,k));
}

fn tests() {
    let (n,k) = (3,6);
    assert_eq!(solve(n,k), 7);
    let (n,k) = (3000,4000);
    assert_eq!(solve(n,k), 6498498);
}
