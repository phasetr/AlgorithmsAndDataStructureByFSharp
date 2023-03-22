extern crate superslice;
use proconio::input;
use superslice::Ext;

fn solve(n:usize,av:Vec<i32>) -> Vec<i32> {
    let mut bv = av.clone();
    bv.sort();
    bv.dedup();
    (0..n).map(|i| bv.lower_bound(&av[i]) as i32 + 1).collect::<Vec<i32>>()
}
#[proconio::fastout]
fn main() {
    input! {
        n: usize,
        av: [i32; n],
    }
    println!("{}", solve(n,av).iter().join(" "));
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn test1() {
        let (n,av):(usize,Vec<i32>) = (5,vec![46,80,11,77,46]);
        assert_eq!(solve(n,av), vec![2,4,1,3,2]);
    }
}
