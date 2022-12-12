// https://atcoder.jp/contests/abc045/submissions/32264329
use proconio::input;

fn solve(s: &str, l: usize, r: usize, sum: usize) -> usize{
    let v = s[l..r].parse::<usize>().unwrap();
    if s.len() == r {
        return v + sum;
    }
    return solve(s, l, r + 1, sum) + solve(s, r, r + 1, sum + v);
}

fn main() {
    input! {
        s: String
    }
    let ans = solve(&s, 0, 1, 0);
    println!("{}", ans);
}
