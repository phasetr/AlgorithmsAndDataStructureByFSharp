// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_2_B/review/4107128/phspls/Rust
fn selection_sort(n: usize, a: &mut Vec<usize>) {
  let mut count: usize = 0;
  for i in 0..n {
    let mut minj = i;
    for j in i..n {
      if a[j] < a[minj] {
        minj = j;
      }
    }
    if minj != i {
      let temp = a[i];
      a[i] = a[minj];
      a[minj] = temp;
      count += 1;
    }
  }
  println!("{}", a.iter().map(|i| i.to_string()).collect::<Vec<String>>().join(" "));
  println!("{}", count);
}

fn main() {
  let mut n = String::new();
  std::io::stdin().read_line(&mut n).ok();
  let n: usize = n.trim().parse::<usize>().unwrap();
  let mut a = String::new();
  std::io::stdin().read_line(&mut a).ok();
  let mut a: Vec<usize> = a.trim().split_whitespace().map(|i| i.parse::<usize>().unwrap()).collect();
  selection_sort(n, &mut a);
}
