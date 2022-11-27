// https://atcoder.jp/contests/abc129/submissions/28049037
use itertools::Itertools;
use proconio::{input, marker::Chars};

fn main() {
  input!{
    h: usize, w: usize,
    s: [Chars; h],
  }

  let mut ys = vec![vec![]; h];
  let mut xs = vec![vec![]; w];
  for i in 0..h {
    ys[i].push(0);
    for j in 0..w {
      if s[i][j] == '#' {
        ys[i].push(j+1);
      }
    }
    ys[i].push(w+1);
  }
  for j in 0..w {
    xs[j].push(0);
    for i in 0..h {
      if s[i][j] == '#' {
        xs[j].push(i+1);
      }
    }
    xs[j].push(h+1);
  }
  let mut lay = vec![vec![0; w]; h];
  for i in 0..h {
    for (&j1, &j2) in ys[i].iter().tuple_windows() {
      for j in j1..j2-1 {
        lay[i][j] += j2-j1-1;
      }
    }
  }
  for j in 0..w {
    for (&i1, &i2) in xs[j].iter().tuple_windows() {
      for i in i1..i2-1 {
        lay[i][j] += i2-i1-1;
      }
    }
  }

  let ans = *lay.iter().flatten().max().unwrap() - 1;
  println!("{}", ans);
}
