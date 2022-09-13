// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_10_D/review/5869406/toriichi/Rust
use std::io;
use std::cmp;
use std::usize;
use std::f64;

fn optimal_bst(p: Vec<f64>, q: Vec<f64>, n: usize,
               e: &mut Vec<Vec<f64>>, w: &mut Vec<Vec<f64>>, root: &mut Vec<Vec<usize>>) {
  for i in 1..=n+1 {
    e[i][i-1] = q[i-1];
    w[i][i-1] = q[i-1];
  }
  for l in 1..=n {
    for i in 1..=n-l+1 {
      let j = i + l - 1;
      e[i][j] = f64::MAX;
      w[i][j] = w[i][j-1] + p[j] + q[j];
      for r in i..=j {
        let t = e[i][r-1] + e[r+1][j] + w[i][j];
        if t < e[i][j] {
          e[i][j] = t;
          root[i][j] = r;
        }
      }
    }
  }
}

fn main() {
  let mut buf = String::new();

  buf.clear();
  io::stdin().read_line(&mut buf).expect("error");
  let vec: Vec<&str> = buf.trim().split_whitespace().collect();
  let n: usize = vec[0].parse().unwrap();

  let mut p: Vec<f64> = vec![];
  let mut q: Vec<f64> = vec![];
  p.push(0.0);

  buf.clear();
  io::stdin().read_line(&mut buf).expect("error");
  let vec: Vec<&str> = buf.trim().split_whitespace().collect();
  for _i in 0..n {
    p.push(vec[_i].parse().unwrap());
  }

  buf.clear();
  io::stdin().read_line(&mut buf).expect("error");
  let vec: Vec<&str> = buf.trim().split_whitespace().collect();
  for _i in 0..=n {
    q.push(vec[_i].parse().unwrap());
  }

  let mut e: Vec<Vec<f64>> = vec![vec![0.0; n+1]; n+2];
  let mut w: Vec<Vec<f64>> = vec![vec![0.0; n+1]; n+2];
  let mut root: Vec<Vec<usize>> = vec![vec![0; n+1]; n+1];

  optimal_bst(p, q, n, &mut e, &mut w, &mut root);

  println!("{}", e[1][n]);
}
