// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_6_B/review/4125234/phspls/Rust
fn partition(a: &mut Vec<usize>, r: usize) {
  let x: usize = a[r];
  let mut i: usize = 0;
  for j in 0..r {
    if a[j] <= x {
      a.swap(i, j);
      i += 1;
    }
  }
  a.swap(i, r);
  println!(
    "{}"
      , a.iter().enumerate()
      .map(|pair| if pair.0 == i { format!("[{}]", pair.1) } else { (pair.1).to_string() })
      .collect::<Vec<String>>()
      .join(" ")
  );
}

fn main() {
  let mut n = String::new();
  std::io::stdin().read_line(&mut n).ok();
  let n: usize = n.trim().parse::<usize>().unwrap();
  let mut a = String::new();
  std::io::stdin().read_line(&mut a).ok();
  let mut a: Vec<usize> = a.trim().split_whitespace().map(|i| i.parse::<usize>().unwrap()).collect();
  partition(&mut a, n-1);
}
