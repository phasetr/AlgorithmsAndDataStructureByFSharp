// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_10_C/review/6157277/enoyo/Rust
use std::io;
use std::cmp;

const DATA_SIZE:usize = 1_010;

fn main() {
  let n:usize = read_line().trim().parse().unwrap();
  let mut dp = [[0u16;DATA_SIZE];DATA_SIZE];

  for _ in 0..n {
    let mut x:Vec<char> = read_line().trim().chars().collect();
    let mut y:Vec<char> = read_line().trim().chars().collect();
    let m = x.len();
    let n = y.len();
    x.insert(0,'_');
    y.insert(0,'_');

    for i in 1..=m {
      for j in 1..=n {
        if x[i]==y[j] {
          dp[i][j] = dp[i-1][j-1]+1;
        } else {
          dp[i][j] = cmp::max(dp[i-1][j],dp[i][j-1]);
        }
      }
    }
    println!("{}",dp[m][n]);
  }
}

fn read_line() -> String {
  let mut buf = String::new();
  io::stdin().read_line(&mut buf).ok();
  buf
}

fn _dump<T:std::fmt::Display>(ary:&Vec<T>) {
  let n = ary.len();
  for i in 0..n {
    if i>0 {
      print!(" ");
    }
    print!("{}",ary[i]);
  }
  println!();
}
