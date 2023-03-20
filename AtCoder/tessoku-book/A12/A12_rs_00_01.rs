// https://atcoder.jp/contests/tessoku-book/submissions/36143840
fn solve(k:i64,av:Vec<i64>) -> i64 {
    let mut ok = 10_000_000_000;
    let mut err = 0;
    while ok - err > 1 {
        let mid = (ok + err) / 2;
        match av.iter().map(|&v| mid / v).sum::<i64>() >= k {
            true => ok = mid,
            false => err = mid
        }
    }
    ok
}
fn main() {
    proconio::input!{n:usize, k:i64, av:[i64; n]}
    println!("{}", solve(k,av));
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn test1() {
        let (n,k,av):(usize,i64,Vec<i64>) = (4,10,vec![1,2,3,4]);
        assert_eq!(solve(k,av), 6);
    }
}
