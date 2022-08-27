// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_5_C/review/2836771/numpy/Rust
use std::f64;

fn norm(x: (f64, f64)) -> f64 {
  (x.0.powi(2) + x.1.powi(2)).sqrt()
}

fn print_tuple(t: (f64, f64)) {
  println!("{} {}", t.0, t.1);
}

fn koch_curve(p1: (f64, f64), p2: (f64, f64), depth: i32) {
  if depth == 0 {
    return;
  }

  let l = ((p2.0 - p1.0) / 3.0, (p2.1 - p1.1) / 3.0);
  let s = (p1.0 + l.0, p1.1 + l.1);
  let t = (p2.0 - l.0, p2.1 - l.1);
  let c = 1.0 / (2.0 * (3.0_f64).sqrt());
  let u = (
    (p1.0 + p2.0) / 2.0 - c * (p2.1 - p1.1),
    (p1.1 + p2.1) / 2.0 + c * (p2.0 - p1.0),
  );

  koch_curve(p1, s, depth - 1);
  print_tuple(s);
  koch_curve(s, u, depth - 1);
  print_tuple(u);
  koch_curve(u, t, depth - 1);
  print_tuple(t);
  koch_curve(t, p2, depth - 1);
}

fn main() {
  let mut line = String::new();
  std::io::stdin().read_line(&mut line).ok();
  let n = line.trim().parse::<i32>().unwrap();

  println!("0 0");
  koch_curve((0.0, 0.0), (100.0, 0.0), n);
  println!("100 0");
}
