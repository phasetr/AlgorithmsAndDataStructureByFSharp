// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_5_A/review/5755911/phspls/Rust
fn main() {
  let mut n = String::new();
  std::io::stdin().read_line(&mut n).ok();
  let n: usize = n.trim().parse().unwrap();
  let mut a = String::new();
  std::io::stdin().read_line(&mut a).ok();
  let a: Vec<usize> = a.trim().split_whitespace().map(|s| s.parse().unwrap()).collect();
  let mut q = String::new();
  std::io::stdin().read_line(&mut q).ok();
  let q: usize = q.trim().parse().unwrap();
  let mut query = String::new();
  std::io::stdin().read_line(&mut query).ok();
  let query: Vec<usize> = query.trim().split_whitespace().map(|s| s.parse().unwrap()).collect();

  let mut patterns = vec![false; 20*2000+1];
  for i in 0..2usize.pow(n as u32) {
    let mut summary = 0usize;
    for j in 0..n {
      if (i >> j) & 1 == 1 {
        summary += a[j];
      }
    }
    patterns[summary] = true;
  }
  for &v in query.iter() {
    if patterns[v] {
      println!("yes");
    } else {
      println!("no");
    }
  }
}
