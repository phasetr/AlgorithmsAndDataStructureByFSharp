use proconio::input;
fn solve(d:usize,n:usize,q:Vec<(usize,usize)>) -> Vec<i32> {
    q.iter().fold(vec![0; d+1], |mut v, &(l, r)| { v[l-1] += 1; v[r] -= 1; v })
        .iter().scan(0, |s, &x| { *s += x; Some(*s) }).collect::<Vec<i32>>()[..d].to_vec()
}
#[proconio::fastout]
fn main() {
    input!{d: usize, n: usize, q: [(usize, usize); n]}
    for c in solve(d,n,q) { println!("{}", c); }
}

fn tests() {
    let (d,n,q):(usize,usize,Vec<(usize,usize)>) = (8,5,vec![(2,3),(3,6),(5,7),(3,7),(1,5)]);
    assert_eq!(solve(d,n,q), vec![1,2,4,3,4,3,2,0])
}
