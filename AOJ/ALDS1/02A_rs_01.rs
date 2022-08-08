// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_2_A/review/4028959/ngtkana/Rust
use std::fmt::Debug;
fn sort<T: PartialOrd + Debug>(v: &mut Vec<T>) -> usize {
  let mut cnt = 0;
  let n = v.len();
  for i in 0..n {
    for j in 1..n-i {
      if v[j-1] > v[j] {
        v.swap(j-1,j);
        cnt += 1;
      }
    }
  }
  cnt
}
fn main() {
  let mut n = String::new();
  std::io::stdin().read_line(&mut n).unwrap();
  let _n: usize = n.trim().parse().unwrap();
  let mut v = String::new();
  std::io::stdin().read_line(&mut v).unwrap();
  let mut v: Vec<i32> = v.trim().split_whitespace().map(|x| x.parse().unwrap()).collect();
  let cnt = sort(&mut v);
  for (i, x) in v.iter().enumerate() {
    if i != 0 {
      print!(" ");
    }
    print!("{}", x);
  }
  println!("");
  println!("{}", cnt);
}
