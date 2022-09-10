// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_9_B/review/4149773/phspls/Rust
fn max_heapify(n: usize, a: &mut Vec<isize>, i: usize) {
  let l = (i+1)*2 - 1;
  let r = (i+1)*2;
  let mut largest: usize = if l < n && a[l] > a[i] { l } else { i };
  if r < n && a[r] > a[largest] {
    largest = r;
  }
  if largest != i {
    a.swap(i, largest);
    max_heapify(n, a, largest);
  }
}

fn build_max_heap(n: usize, a: &mut Vec<isize>) {
  for i in (0..n/2).rev() {
    max_heapify(n, a, i);
  }
}

fn main() {
  let mut n = String::new();
  std::io::stdin().read_line(&mut n).ok();
  let n: usize = n.trim().parse().unwrap();
  let mut a = String::new();
  std::io::stdin().read_line(&mut a).ok();
  let mut a: Vec<isize> = a.trim().split_whitespace().map(|i| i.parse().unwrap()).collect();
  build_max_heap(n, &mut a);
  println!(" {}", a.iter().map(|i| i.to_string()).collect::<Vec<String>>().join(" "));
}
