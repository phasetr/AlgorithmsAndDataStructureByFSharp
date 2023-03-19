use proconio::input;
fn solve(h:usize,w:usize,xa:Vec<Vec<i32>>,q:i32,ia:Vec<(usize,usize,usize,usize)>) -> Vec<i32> {
    let mut svv = vec![vec![0;w+1];h+1];
    for i in 0..h { for j in 0..w { svv[i+1][j+1] = svv[i+1][j] + xa[i][j]; } }
    for i in 0..h { for j in 0..w { svv[i+1][j+1] += svv[i][j+1]; } }
    ia.into_iter().map(|(a,b,c,d)| svv[c][d] - svv[c][b-1] - svv[a-1][d] + svv[a-1][b-1] ).collect::<Vec<i32>>()
}
#[proconio::fastout]
fn main() {
    input! {
        h:usize,w:usize,
        xa: [[i32;w];h],
        q:i32,
        ia: [(usize,usize,usize,usize);q],
    }
    for v in solve(h,w,xa,q,ia) { println!("{}", v); }
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn test1() {
        let (h,w,xa,q,ia):(usize,usize,Vec<Vec<i32>>,i32,Vec<(usize,usize,usize,usize)>) = (5,5,vec![vec![2,0,0,5,1],vec![1,0,3,0,0],vec![0,8,5,0,2],vec![4,1,0,0,6],vec![0,9,2,7,0]],2,vec![(2,2,4,5),(1,1,5,5)]);
        assert_eq!(solve(h,w,xa,q,ia), vec![25, 56]);
    }
}
