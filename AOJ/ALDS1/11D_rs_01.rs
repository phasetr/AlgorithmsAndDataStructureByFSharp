// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_11_D/review/5869917/toriichi/Rust
use std::io;
use std::usize;

fn main() {
  let mut buf = String::new();

  buf.clear();
  io::stdin().read_line(&mut buf).expect("error");
  let vec: Vec<&str> = buf.trim().split_whitespace().collect();
  let n: usize = vec[0].parse().unwrap();
  let m: usize = vec[1].parse().unwrap();

  let mut a = vec![0; n];
  for i in 0..n {
    a[i] = i;
  }

  for i in 0..m {
    buf.clear();
    io::stdin().read_line(&mut buf).expect("error");
    let vec: Vec<&str> = buf.trim().split_whitespace().collect();
    let b: usize = vec[0].parse().unwrap();
    let c: usize = vec[1].parse().unwrap();
    let bp = find_root(&a, b);
    let cp = find_root(&a, c);
    if bp < cp {
      a[cp] = bp;
    }
    else {
      a[bp] = cp;
    }
  }

  buf.clear();
  io::stdin().read_line(&mut buf).expect("error");
  let vec: Vec<&str> = buf.trim().split_whitespace().collect();
  let q: usize = vec[0].parse().unwrap();

  for i in 0..q {
    buf.clear();
    io::stdin().read_line(&mut buf).expect("error");
    let vec: Vec<&str> = buf.trim().split_whitespace().collect();
    let mut b: usize = vec[0].parse().unwrap();
    let mut c: usize = vec[1].parse().unwrap();

    let bp = find_root(&a, b);
    let cp = find_root(&a, c);
    if bp == cp {
      println!("yes")
    }
    else {
      println!("no");
    }
  }
}

fn find_root(a: &Vec<usize>, i: usize) -> usize {
  if i == a[i] {
    return i;
  }
  find_root(a, a[i])
}
