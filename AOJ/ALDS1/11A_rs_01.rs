// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_11_A/review/4153479/phspls/Rust
fn main() {
  let mut n = String::new();
  std::io::stdin().read_line(&mut n).ok();
  let n: usize = n.trim().parse::<usize>().unwrap();
  let mut matrix: Vec<Vec<usize>> = vec![vec![0; n]; n];
  for i in 0..n {
    let mut a = String::new();
    std::io::stdin().read_line(&mut a).ok();
    let a: Vec<usize> = a.trim().split_whitespace().map(|i| i.parse::<usize>().unwrap()).collect();
    for j in a.iter().skip(2) {
      matrix[i][*j-1] = 1;
    }
  }
  for v in matrix {
    println!("{}", v.iter().map(|i| i.to_string()).collect::<Vec<String>>().join(" "));
  }
}
