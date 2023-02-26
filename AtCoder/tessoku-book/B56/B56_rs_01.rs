// https://atcoder.jp/contests/tessoku-book/submissions/35650958
use proconio::{input, marker::{Chars, Usize1}};
#[proconio::fastout]
fn main() {
    input!{
        n:usize,q:usize,
        s:Chars,
        ab:[(Usize1,Usize1);q],
    }
    let mods = 1000000007i64;
    let mut v = vec![0i64];
    let mut v2 = vec![0i64];
    let mut pow100 = vec![1];
    let mut sum = (0,0);
    for i in 0..n {
        pow100.push(pow100[i]*100 % mods);
    }
    for i in 0..n {
        sum.0 = sum.0 * 100 + s[i] as i64 - 97;
        sum.1 = sum.1 * 100 + s[n-1-i] as i64 - 97;
        sum.0 %= mods;
        sum.1 %= mods;
        v.push(sum.0);
        v2.push(sum.1);
    }
    for (a,b) in ab{
        let (mut f,mut r) = (v[b+1]-v[a]*pow100[b+1-a]%mods
                            ,v2[n-a]-v2[n-b-1]*pow100[b+1-a]%mods);
        if f < 0{f += mods;}
        if r < 0{r += mods;}
        if r == f{
            println!("Yes");
        }else{
            println!("No");
        }
    }
}
