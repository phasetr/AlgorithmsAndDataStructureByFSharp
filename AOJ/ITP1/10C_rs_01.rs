// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_10_C/review/4293143/wanimaru/Rust
use std::io;

fn main() {
  loop {
    let mut s = String::new();
    io::stdin().read_line(&mut s).unwrap();
    let n: f64 = s.trim().parse().unwrap();
    if n == 0. {
      break;
    }

    let mut s = String::new();
    io::stdin().read_line(&mut s).unwrap();
    let v: Vec<f64> = s.trim().split_whitespace().map(|x| x.parse().unwrap()).collect::<_>();
    let sum: f64 = v.iter().sum();
    let m: f64 = sum / n;
    let tmp: f64 = v.iter().map(|x| (x - m).powi(2)).sum();
    let ans = (tmp / n).sqrt();

    println!("{}", ans);
  }
}
