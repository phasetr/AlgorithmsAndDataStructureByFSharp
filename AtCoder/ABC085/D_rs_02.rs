// https://atcoder.jp/contests/abc085/submissions/23193149
use proconio::input;

fn main() {
    input!{n:u64,mut h:u64,mut abn:[(u64,u64);n]}
    let weapon:u64 = abn.iter().fold(0,|a,v| a.max(v.0));
    let mut throws:Vec<u64> = abn.into_iter().map(|x| x.1).filter(|v| *v > weapon).collect();
    throws.sort();
    throws.reverse();

    let mut ans = 0;
    for v in throws{
        if h <= v{
            println!("{}",ans+1);
            return;
        }
        h -= v;
        ans += 1;
    }
    println!("{}",ans + (h-1) / weapon + 1);
}
