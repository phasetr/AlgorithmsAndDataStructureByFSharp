// https://atcoder.jp/contests/abc064/submissions/26578968
#[allow(unused_imports)]
use proconio::{input,marker::*};
fn main() {
    input!{
        _:usize,
        s:Chars,
    }
    let mut cnt=0;
    let mut open=0;
    for &c in &s{
        if c=='('{
            cnt+=1
        }else if cnt>0{
            cnt-=1
        }else{
            open+=1
        }
    }
    println!("{}{}{}",
        vec!['(';open].iter().collect::<String>(),
        s.iter().collect::<String>(),
        vec![')';cnt].iter().collect::<String>());
}
