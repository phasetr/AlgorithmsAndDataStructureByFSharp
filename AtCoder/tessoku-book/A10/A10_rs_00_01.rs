use proconio::input;
use std::cmp;
fn solve(av:Vec<usize>,iv:Vec<(usize,usize)>)->Vec<i32> {
    let lv:Vec<usize> = av.iter().scan(0, |s,x| { *s = cmp::max(*s,*x); Some(*s) }).collect::<Vec<usize>>();
    let mut bv = av.clone(); bv.reverse();
    let mut rv:Vec<usize> = bv.iter().scan(0, |s,x| { *s = cmp::max(*s,*x); Some(*s) }).collect::<Vec<usize>>();
    rv.reverse();
    iv.iter().map(|(l,r)| cmp::max(lv[l-2],rv[r-1]) as i32).collect::<Vec<i32>>()
}
#[proconio::fastout]
fn main() {
    input!{n: usize, av: [usize; n], d: usize, iv: [(usize, usize); d]};
    for v in solve(av,iv) { println!("{}", v); }
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn test1() {
        let (n,av,d,iv):(usize,Vec<usize>,usize,Vec<(usize,usize)>) = (7,vec![1,2,5,5,2,3,1],2,vec![(3,5),(4,6)]);
        assert_eq!(solve(av,iv),vec![3,5]);
    }
}
