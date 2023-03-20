extern crate superslice;
use proconio::input;
use superslice::*;
fn solve(n:usize,k:i32,av:Vec<i32>) -> usize {
    (0..n).fold(0, |acc, i| {
        let pick = av[i];
        let lb = av.lower_bound(&(pick - k));
        acc + i - lb
    })
}
#[proconio::fastout]
fn main() {
    input! { n: usize, k: i32, av: [i32; n] }
    println!("{}", solve(n,k,av));
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn test1() {
        let (n,k,av):(usize,i32,Vec<i32>) = (7,10,vec![11,12,16,22,27,28,31]);
        assert_eq!(solve(n,k,av), 11);
    }
}
