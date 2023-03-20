use proconio::input;
use std::collections::HashMap;

fn solve(x:usize,av:Vec<usize>) -> i32 {
    av.binary_search(&x).unwrap() as i32 + 1
}
#[proconio::fastout]
fn main() {
    proconio::input!{n: usize, x: usize, av: [; n]}
    println!("{}", solve(x,av));
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn test1() {
        let (n,x,av):(usize,usize,Vec<usize>) = (15,47,vec![11,13,17,19,23,29,31,37,41,43,47,53,59,61,67]);
        assert_eq!(solve(x,av),11);
        let (n,x,av):(usize,usize,Vec<usize>) = (10,80,vec![10,20,30,40,50,60,70,80,90,100]);
        assert_eq!(solve(x,av),8);
    }
}
