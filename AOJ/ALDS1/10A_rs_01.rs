// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_10_A/review/5934640/phspls/Rust
fn main() {
  let mut n = String::new();
  std::io::stdin().read_line(&mut n).ok();
  let n: usize = n.trim().parse().unwrap();
  if n <= 1 {
    println!("{}", 1);
  } else {
    let mut result = vec![1,1];
    for i in 2..=n {
      result.push(result[i-1] + result[i-2]);
    }
    println!("{}", result[result.len()-1]);
  }
}
