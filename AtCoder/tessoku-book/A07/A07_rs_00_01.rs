use proconio::input;
fn solve(d:usize,n:usize,q:Vec<(usize,usize)>) -> Vec<usize> {
    q.iter().fold(vec![0usize; d], |mut v, &(l, r)| {
        for i in l-1..=r-1 {v[i] += 1;}
        v
    })
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
