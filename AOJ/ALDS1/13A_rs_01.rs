// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_13_A/review/5920409/boiler2/Rust
use std::io::*;
use std::str::FromStr;

fn read<T: FromStr>() -> T {
  let s = stdin();
  let s = s.lock();
  let s: String = s.bytes()
    .map(|c| c.expect("failed reading char") as char)
    .skip_while(|c| c.is_whitespace())
    .take_while(|c| !c.is_whitespace())
    .collect();
  s.parse().ok().expect("failed parsing")
}

fn main() {
  let n: usize = read();
  let mut xy = vec![];
  for _ in 0..n {
    let y: usize = read();
    let x: usize = read();
    xy.push((x, y));
  }
  let mut p: Vec<usize> = (0..8).collect();
  let mut table: Vec<Vec<bool>>;
  loop {
    table = vec![vec![false; 8]; 8];
    for (y, &x) in p.iter().enumerate() {
      table[y][x] = true;
    }
    //入力であたえられた位置にコマが置かれているか
    let mut ok = true;
    for &(x, y) in &xy {
      if !table[y][x] {
        ok = false;
      }
    }
    if ok {
      //斜め方向にコマが置かれていないか
      let mut a = table.clone();
      let ok2 = diag(&mut a);
      a.reverse();
      let ok3 = diag(&mut a);
      if ok2 && ok3 {
        break;
      }
    }
    if !p.next_permutation() {
      break;
    }
  }
  for y in 0..8 {
    for x in 0..8 {
      print!("{}", if table[y][x] { "Q" } else { "." });
    }
    println!();
  }
}

// y = ax + b (a = -1, 0 <= b < 16
fn diag(table: &Vec<Vec<bool>>) -> bool {
  for b in 0..16 {
    let mut cnt = 0;
    for x in 0..=b {
      let y = b - x;
      if y < 8 && x < 8 && table[y][x] {
        cnt += 1;
      }
    }
    if cnt > 1 {
      return false;
    }
  }
  true
}

trait LexicalPermutation {
  fn next_permutation(&mut self) -> bool;
}

impl<T> LexicalPermutation for [T] where T: Ord {
  fn next_permutation(&mut self) -> bool {
    if self.len() < 2 {
      return false;
    }
    let mut i = self.len() - 1;
    while i > 0 && self[i-1] >= self[i] {
      i -= 1;
    }
    if i == 0 {
      return false;
    }
    let mut j = self.len() - 1;
    while j >= i && self[j] <= self[i-1] {
      j -= 1;
    }
    self.swap(j, i-1);
    self[i..].reverse();
    true
  }
}
