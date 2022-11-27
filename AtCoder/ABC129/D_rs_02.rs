// https://atcoder.jp/contests/abc129/submissions/34484584
#![allow(non_snake_case)]
use proconio::{fastout, input, marker::Chars};

#[fastout]
fn main() {
  input! {
    H: usize, W: usize,
    mut S: [Chars; H]
  }
  let mut A = vec![vec![0; W]; H];
  for _ in 0..4 {
    let (h, w) = (A.len(), A[0].len());
    for i in 0..h {
      let mut t = 0;
      for j in 1..w {
        if S[i][j] == '.' && S[i][j - 1] == '.' {
          t += 1;
        } else {
          t = 0;
        }
        A[i][j] += t;
      }
    }
    S = rotate90(&mut S);
    A = rotate90(&mut A);
  }
  let mut ans = 0;
  for i in 0..H {
    for j in 0..W {
      if S[i][j] == '.' {
        ans = ans.max(A[i][j] + 1);
      }
    }
  }
  println!("{}", ans);
}

fn rotate90<T: Default + Clone>(a: &Vec<Vec<T>>) -> Vec<Vec<T>> {
  let n = a.len();
  let m = a[0].len();
  let d = T::default();
  let mut b = vec![vec![d; n]; m];
  for i in 0..n {
    for j in 0..m {
      b[j][i] = a[n - 1 - i][j].clone();
    }
  }
  b
}
