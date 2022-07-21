// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_7_C/review/4094767/phspls/Rust
fn main() {
  let mut rc = String::new();
  std::io::stdin().read_line(&mut rc).ok();
  let rc: Vec<u64> = rc.trim().split_whitespace().map(|s| s.parse::<u64>().unwrap()).collect();

  let mut matrix = vec![];
  for _ in 0..rc[0] {
    let mut row = String::new();
    std::io::stdin().read_line(&mut row).ok();
    let mut row: Vec<u64> = row.trim().split_whitespace().map(|s| s.parse::<u64>().unwrap()).collect();
    let r_sum = row.iter().sum::<u64>();
    row.push(r_sum);
    matrix.push(row);
  }

  let summary: Vec<u64> = (0..(rc[1] + 1)).map(|i| matrix.iter().map(|m| m[i as usize]).sum::<u64>()).collect();
  matrix.push(summary);

  for i in 0..(rc[0] + 1) {
    println!("{}", matrix[i as usize].iter().map(|j| j.to_string()).collect::<Vec<String>>().join(" "));
  }
}
