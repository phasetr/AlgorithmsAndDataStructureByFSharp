// https://atcoder.jp/contests/abc151/submissions/26994069
use proconio::{fastout, input, marker::*};
use std::collections::*;
use superslice::Ext;
const dydx: [(i64, i64); 4] = [(-1, 0), (0, 1), (1, 0), (0, -1)];
const INF: usize = usize::max_value() / 2;
const IINF: i64 = i64::max_value() / 2;
const MOD1: usize = 1_000_000_007;
const MOD2: usize = 998_244_353;

#[fastout]
fn main() {
  input!(h: usize, w: usize, s: [Chars; h]);
  let mut ans = 0;
  for i in 0..h {
    for j in 0..w {
      if s[i][j] == '#' {
        continue;
      }
      let mut s = s.clone();
      let mut q = std::collections::VecDeque::new();
      s[i][j] = '#';
      q.push_back((i, j, 0));
      while let Some((i, j, d)) = q.pop_front() {
        ans = d.max(ans);
        for &(x, y) in [(i + 1, j), (i - 1, j), (i, j + 1), (i, j - 1)].iter() {
          if x < h && y < w && s[x][y] == '.' {
            s[x][y] = '#';
            q.push_back((x, y, d + 1));
          }
        }
      }
    }
  }
  println!("{}", ans);
}
