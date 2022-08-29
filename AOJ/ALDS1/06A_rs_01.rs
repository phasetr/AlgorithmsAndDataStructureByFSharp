// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_6_A/review/4125038/phspls/Rust
fn bucket_sort(a: Vec<usize>) {
  let mut bucket: Vec<usize> = vec![0; 10001];
  for i in a { bucket[i] += 1; }
  println!("{}", bucket.iter().enumerate().flat_map(|pair| (0..*(pair.1)).map(|_| (pair.0).to_string()).collect::<Vec<String>>()).collect::<Vec<String>>().join(" "));
}

fn main() {
  let mut n = String::new();
  std::io::stdin().read_line(&mut n).ok();
  let n: usize = n.trim().parse::<usize>().unwrap();
  let mut a = String::new();
  std::io::stdin().read_line(&mut a).ok();
  let a: Vec<usize> = a.trim().split_whitespace().map(|i| i.parse::<usize>().unwrap()).collect();
  bucket_sort(a);
}
