// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_6_D/review/5159513/boiler21/Rust
use std::cmp::min;

fn minimum_const_sort(a: &Vec<usize>, n: usize, s: usize) -> usize {
  let mut ans: usize = 0;
  let mut b = a.clone();
  let mut v = vec![false; a.len()];
  let mut t = vec![0; 10001];

  b.sort();

  for i in 0..n {
    t[b[i]] = i;
  }

  for i in 0..n {
    if v[i] {
      continue;
    }
    let mut cur: usize = i;
    let mut sumw: usize = 0;
    let mut minw: usize = 10001;
    let mut j: usize = 0;
    loop {
      v[cur] = true;
      j += 1;
      let w = a[cur];
      minw = min(minw, w);
      sumw += w;
      cur = t[w];
      if v[cur] {
        break;
      }
    }
    ans += min(sumw + (j - 2) * minw,  sumw + minw + (j + 1) * s);
  }
  ans
}

fn main() {
  let mut s = String::new();
  std::io::stdin().read_line(&mut s).unwrap();
  let n: usize = s.trim().parse().unwrap();

  s.clear();
  std::io::stdin().read_line(&mut s).unwrap();
  let a: Vec<usize> = s.split_whitespace().map(|x| x.parse().unwrap()).collect();

  let s: usize = *a.iter().min().unwrap();

  let w = minimum_const_sort(&a, n, s);

  println!("{}", w);
}
