// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_2_D/review/5291743/boiler2/Rust
use std::io::*;
use std::str::FromStr;

fn rin<T: FromStr>() -> T {
  let s = stdin();
  let s = s.lock();
  let s: String = s.bytes().map(|c| c.unwrap() as char)
    .skip_while(|c| c.is_whitespace()).take_while(|c| !c.is_whitespace())
    .collect();
  s.parse().ok().unwrap()
}

fn insert_sort(a: &mut Vec<i32>, n: usize, g: usize) -> usize {
  let mut cnt = 0;
  for i in g..n {
    let v = a[i];
    let mut j = i;
    while j >= g && a[j-g] > v {
      a[j] = a[j-g];
      j -= g;
      cnt += 1;
    }
    a[j] = v;
  }
  cnt
}

fn shell_sort(a: &mut Vec<i32>, n: usize) -> usize {
  let mut cnt = 0;

  let mut j = 1;
  let mut gs: Vec<usize> = Vec::new();
  while j <= n {
    gs.push(j);
    j = 3 * j + 1;
  }
  gs.reverse();

  println!("{}", gs.len());
  let ss: Vec<String> = gs.iter().map(|g| g.to_string()).collect();
  println!("{}", ss.join(" "));

  for g in &gs { cnt += insert_sort(a, n, *g); }

  cnt
}

fn main() {
  let n: usize = rin();

  let mut xs: Vec<i32> = vec![0; n];
  for i in 0..n { xs[i] = rin(); }

  let cnt = shell_sort(&mut xs, n);

  println!("{}", cnt);
  for x in &xs {
    println!("{}", *x);
  }
}
