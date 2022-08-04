// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_11_D/review/5228651/kotet/Rust
use std::f64;
use std::f64::consts::PI;
use std::i64;
use std::io::Read;

fn main() {
  let mut buf = String::new();
  let mut sc = Scanner::new(Box::new(&mut buf));
  // std::io::stdin().read_to_string(&mut buf).unwrap();

  let n = sc.next();
  let mut ds = vec![[0; 6]; n];
  for i in 0..n {
    for j in 0..6 {
      ds[i][j] = sc.next();
    }
  }
  for i in 0..n {
    for j in i + 1..n {
      if equals(ds[i], ds[j]) {
        println!("No");
        return;
      }
    }
  }
  println!("Yes");
}

fn equals(mut a: [i64; 6], b: [i64; 6]) -> bool {
  let s = "NWSNWSNWSNWS";
  let t = &(String::new() + "N" + s + "N" + s + "N" + s + "N" + s);
  let seq = String::new() + "W" + t + "W" + t + "W" + t + "W" + t;
  for op in seq.chars() {
    if a == b {
      return true;
    }
    a = match op {
      'N' => roll_n(a),
      'S' => roll_s(a),
      'W' => roll_w(a),
      'E' => roll_e(a),
      _ => panic!(),
    }
  }
  return false;
}

fn roll_n(d: [i64; 6]) -> [i64; 6] {
  [d[1], d[5], d[2], d[3], d[0], d[4]]
}

fn roll_s(d: [i64; 6]) -> [i64; 6] {
  [d[4], d[0], d[2], d[3], d[5], d[1]]
}

fn roll_w(d: [i64; 6]) -> [i64; 6] {
  [d[2], d[1], d[5], d[0], d[4], d[3]]
}

fn roll_e(d: [i64; 6]) -> [i64; 6] {
  [d[3], d[1], d[0], d[5], d[4], d[2]]
}

fn swap<'a, T: Copy>(a: &'a mut T, b: &'a mut T) {
  let tmp = *a;
  *a = *b;
  *b = tmp;
}

struct Scanner<'a> {
  iter: std::str::SplitWhitespace<'a>,
}
impl Scanner<'_> {
  fn new<'a>(buf: Box<&'a mut String>) -> Scanner<'a> {
    std::io::stdin().read_to_string(&mut **buf).unwrap();
    Scanner {
      iter: buf.split_whitespace(),
    }
  }
  fn next<T: std::str::FromStr>(&mut self) -> T {
    let s = self.iter.next().unwrap();
    match s.parse() {
      Ok(x) => x,
      Err(_) => panic!("failed to parse {}", s),
    }
  }
  fn next_int(&mut self) -> i64 {
    self.next()
  }
}
