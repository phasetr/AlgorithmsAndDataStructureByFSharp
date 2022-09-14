// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_11_A/review/5739663/jamkernel/Rust
use std::io;

fn main() {
  let mut buf = String::new();
  io::stdin().read_line(&mut buf).ok();
  let n: usize = buf.trim().parse().unwrap();
  buf.clear();

  let mut adj_matrix = vec![vec![0; n]; n];

  for _ in 0..n {
    let mut buf = String::new();
    io::stdin().read_line(&mut buf).ok();
    let adj_list:Vec<usize> = buf.trim().split_whitespace().map(|s| s.parse().unwrap()).collect();

    let i = adj_list[0] - 1;

    for j_i in 2..adj_list.len() {
      let j = adj_list[j_i] - 1;
      adj_matrix[i][j] = 1;
    }
  }

  for row in adj_matrix.iter() {
    for i in 0..row.len() {
      print!("{}", row[i]);
      if i != row.len()-1 { print!(" "); }
    }
    println!();
  }
}
