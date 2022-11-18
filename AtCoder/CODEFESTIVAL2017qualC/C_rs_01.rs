// https://atcoder.jp/contests/code-festival-2017-qualc/submissions/30803155
use proconio::{input};
use proconio::marker::Chars;

fn main() {
    input! {s:Chars}
    let mut l = 0;
    let mut r = s.len()-1;
    let mut ans = 0;

    while l < r{
        if s[l] == s[r] {
            l += 1;
            r -= 1;
        }else if s[l] == 'x'{
            ans += 1;
            l += 1;
        }else if s[r] == 'x'{
            ans += 1;
            r -= 1;
        }else{
            println!("-1");
            return
        }
    }
    println!("{}",ans);
}
