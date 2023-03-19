// https://atcoder.jp/contests/tessoku-book/submissions/36279639
use proconio::input;
fn solve(h:usize,w:usize,n:usize,iv:Vec<(usize,usize,usize,usize)>) -> Vec<Vec<i32>> {
    let mut ans = vec![vec![0; w+1]; h+1];
    for (a,b,c,d) in iv {
        ans[a-1][b-1]+=1;
        ans[a-1][d]-=1;
        ans[c][b-1]-=1;
        ans[c][d]+=1;
    }
    for i in 0..h { for j in 1..w { ans[i][j]+=ans[i][j-1]; } }
    for i in 0..w { for j in 1..h { ans[j][i]+=ans[j-1][i]; } }
    ans[0..h].iter().map(|x| x[0..w].to_vec()).collect::<Vec<Vec<i32>>>()
}
fn main() {
    input! {
        h: usize,
        w: usize,
        n: usize,
        iv: [(usize,usize,usize,usize); n],
    };
    for x in solve(h,w,n,iv) { println!("{}", x.iter().map(|x| x.to_string()).collect::<Vec<String>>().join(" ")); }
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn test1() {
        let (h,w,n,iv):(usize,usize,usize,Vec<(usize,usize,usize,usize)>) = (5,5,2,vec![(1,1,3,3),(2,2,4,4)]);
        assert_eq!(solve(h,w,n,iv), vec![vec![1,1,1,0,0],vec![1,2,2,1,0],vec![1,2,2,1,0],vec![0,1,1,1,0],vec![0,0,0,0,0]]);
    }
}
