// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_6_C/review/4127581/phspls/Rust
fn partition(a: &mut Vec<(String, usize)>, p: usize, r: usize, flg: &mut bool) -> usize {
  let x: usize = a[r].1;
  let mut i: usize = p;
  for j in p..r {
    if a[j].1 <= x {
      *flg = *flg || (i < j && a[i].1 == a[j].1);
      a.swap(i, j);
      i += 1;
    }
  }
  *flg = *flg || (i < r && a[i].1 == a[r].1);
  a.swap(i, r);
  i
}

fn quicksort(a: &mut Vec<(String, usize)>, p: usize, r: usize, flg: &mut bool) {
  if p < r {
    let q: usize = partition(a, p, r, flg);
    quicksort(a, p, q-1, flg);
    quicksort(a, q+1, r, flg);
  }
}

fn main() {
  let mut n = String::new();
  std::io::stdin().read_line(&mut n).ok();
  let n: usize = n.trim().parse::<usize>().unwrap();
  let mut a: Vec<(String, usize)> = vec![];
  for _ in 0..n {
    let mut b = String::new();
    std::io::stdin().read_line(&mut b).ok();
    let b: Vec<&str> = b.trim().split_whitespace().collect();
    a.push((b[0].to_string(), b[1].parse::<usize>().unwrap()))
  }
  let mut cloned = a.clone();
  cloned.sort_by_key(|a| a.1);
  let mut flg = false;
  quicksort(&mut a, 0, n-1, &mut flg);
  if !a.iter().zip(cloned.iter()).any(|i| (i.0).0 != (i.1).0) {
    println!("Stable");
  } else {
    println!("Not stable");
  }
  for i in 0..n {
    println!("{} {}", a[i].0, a[i].1);
  }
}
