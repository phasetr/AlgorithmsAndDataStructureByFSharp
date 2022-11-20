// https://atcoder.jp/contests/abc084/submissions/16929798
fn main() {
    proconio::input! {
        q: usize,
        lr: [(usize,usize);q],
    }
    let m=lr.iter().map(|lr|lr.1).max().unwrap()+1;
    let mut p=vec![true;m];
    p[0]=false;
    p[1]=false;
    for i in 2..m/2 {
        if p[i] {
            for p in p[i*2..].iter_mut().step_by(i) {
                *p=false;
            }
        }
    }
    let mut s=vec![0;m];
    for i in 2..m {
        s[i]=s[i-1]+if p[i]&&p[(i+1)/2] {1} else {0};
    }
    for (l,r) in lr {
        println!("{}",s[r]-s[l-1]);
    }
}
