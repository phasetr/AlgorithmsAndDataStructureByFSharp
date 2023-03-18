// https://atcoder.jp/contests/tessoku-book/submissions/36116430
use proconio::input;
fn solve(n:usize,q:usize,a:Vec<usize>,pq:Vec<(usize,usize)>) -> Vec<usize> {
    let mut x = a.clone(); x.insert(0,0usize);
    let x = x.iter().scan(0, |cum, x|{ *cum += x; Some(*cum) }).collect::<Vec<usize>>();
    pq.iter().map(|(l,r)| x[*r]-x[l-1] ).collect::<Vec<usize>>()
}
#[proconio::fastout]
fn main() {
    input!{n: usize, q: usize, a: [usize; n], pq: [(usize, usize); q]}
    for v in solve(n,q,a,pq) { println!("{}", ans[i]); }
}

fn tests() {
    let (n,q,a,pq): (usize,usize,Vec<usize>,Vec<(usize,usize)>) = (10,5,vec!(8,6,9,1,2,1,10,100,1000,10000),vec!((2,3),(1,4),(3,9),(6,8),(1,10)));
    assert_eq!(solve(n,q,a,pq),vec!(15,24,1123,111,11137));
}
