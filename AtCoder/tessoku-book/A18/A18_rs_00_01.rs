// https://atcoder.jp/contests/tessoku-book/submissions/36143556
/*
:dep bitset-fixed = "0.1.0"
 */
use bitset_fixed::BitSetFixed;

fn solve(n:usize,s:usize,av:Vec<usize>) -> String {
    let mut b = bitset_fixed::BitSet::new(s+1);
    b.set(0, true);
    av.iter().for_each(|&v| b.shl_or(v));
    match b[s] {
        true => "Yes".to_string(),
        false => "No".to_string()
    }
}
#[proconio::fastout]
fn main() {
    proconio::input!{n: usize, s: usize, av: [usize; n]};
    println!("{}", solve(n,s,av));
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn test1() {
        let (n,s,av):(usize,usize,Vec<usize>) = (3,7,vec![2,2,3]);
        assert_eq!(solve(n,s,av), "Yes");
        let (n,s,av):(usize,usize,Vec<usize>) = (4,11, vec![3,1,4,5]);
        assert_eq!(solve(n,s,av), "No");
    }
}
