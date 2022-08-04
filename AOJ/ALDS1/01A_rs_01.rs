// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_1_A/review/4105807/phspls/Rust
fn insertion_sort(n: usize, a: &mut Vec<usize>) {
  for i in 0..n {
    let v = a[i];
    let mut j: isize = (i as isize) - 1;
    while j >= 0 && a[j as usize] > v {
      a[(j+1) as usize] = a[j as usize];
      j -= 1;
    }
    a[(j+1) as usize] = v;
    println!("{}", a.iter().map(|k| k.to_string()).collect::<Vec<String>>().join(" "));
  }
}

fn main() {
  let mut n = String::new();
  std::io::stdin().read_line(&mut n).ok();
  let n: usize = n.trim().parse::<usize>().unwrap();
  let mut a = String::new();
  std::io::stdin().read_line(&mut a).ok();
  let mut a: Vec<usize> = a.trim().split_whitespace().map(|i| i.parse::<usize>().unwrap()).collect();
  insertion_sort(n, &mut a);
}
