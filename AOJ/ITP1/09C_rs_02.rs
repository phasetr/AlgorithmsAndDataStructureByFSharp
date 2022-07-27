// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_9_C/review/4097503/phspls/Rust
fn main() {
  let mut n = String::new();
  std::io::stdin().read_line(&mut n).ok();
  let n = n.trim().parse::<usize>().unwrap();
  let mut result = vec![0, 0];
  for _ in 0..n {
    let mut s = String::new();
    std::io::stdin().read_line(&mut s).ok();
    let ss: Vec<&str> = s.trim().split_whitespace().collect();
    if ss[0] == ss[1] {
      result[0] += 1;
      result[1] += 1;
    } else if ss[0] > ss[1] {
      result[0] += 3;
    } else {
      result[1] += 3;
    }
  }
  println!("{} {}", result[0], result[1]);
}
