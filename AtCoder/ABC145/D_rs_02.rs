// https://atcoder.jp/contests/abc145/submissions/23463130
use proconio::input;
fn ext_gcd(a:i64,b:i64,x:&mut i64,y:&mut i64)->i64{
    if b==0{
        *x=1;*y=0;
        a
    }else {
        let d=ext_gcd(b,a%b,y,x);
        *y-=a/b*(*x);
        d
    }
}
fn modulo(a:i64,m:i64)->i64{(a%m+m)%m}
fn mod_inv(a:i64,m:i64)->i64{
    let mut x=0;
    let mut y=0;
    ext_gcd(a,m,&mut x,&mut y);
    modulo(x,m)
}
fn com_mod(mut n:i64,c:i64,m:i64)->i64{
    let mut den=1;
    let mut num=1;
    for i in 1..=c{
        den=den*n%m;
        num=num*i%m;
        n-=1;
    }
    modulo(den*mod_inv(num,m),m)
}
fn main() {
    let md:i64=1_000_000_007;
    input!(x:i64,y:i64);
    let mut m = 2*y-x;
    let mut n = 2*x-y;
    if m<0 || m%3!=0 || n<0 || n%3!=0{
        println!("0");
        return;
    }
    m/=3;
    n/=3;
    println!("{}",com_mod(m+n,n,md));
}
