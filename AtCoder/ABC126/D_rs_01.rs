// https://atcoder.jp/contests/abc126/submissions/22723221
use proconio::input;

fn dfs(v:i32, p:i32, c:u8, g:&Vec<Vec<(i32,u8)>>, r:&mut Vec<u8>){
    r[v as usize]=c;
    for e in &g[v as usize]{
        if e.0==p{continue;}
        if e.1==0{dfs(e.0,v,c,g,r);}
        else{dfs(e.0,v,c^1,g,r);}
    }
}
fn main() {
    input!{n:usize,};
    let mut r=vec![0u8;n];
    let mut g=vec![vec![(0i32,0u8);0];n];
    for _i in 0..n-1{
        input!{u:i32,v:i32,w:usize,};
        g[(u-1) as usize].push((v-1,(w&1) as u8));
        g[(v-1) as usize].push((u-1,(w&1) as u8));
    }
    dfs(0,-1,1,&g,&mut r);
    for c in &r{println!("{}",c);}
}
