use proconio::input;
fn solve(n: i32, k: i32) -> i32 {
    let mut ans = 0;
    for i in 1..=n {
        for j in 1..=n {
            let x = k-i-j;
            if x >= 1 && x <= n { ans += 1; }
        }
    }
    ans
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
