// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_7_D/review/4917676/cafebabe/Rust
use std::io;

fn main() {
  let v = input_i32_vals();
  let n = v[0];
  let m = v[1];
  let l = v[2];

  let mut a = vec![vec![0; m as usize]; n as usize];
  let mut b = vec![vec![0; l as usize]; m as usize];

  for i in 0..n { a[i as usize] = input_i32_vals(); }
  for i in 0..m { b[i as usize] = input_i32_vals(); }

  for i in 0..n {
    for j in 0..l {
      let mut c: i64 = 0;
      for k in 0..m {
        c += a[i as usize][k as usize] as i64 * b[k as usize][j as usize] as i64;
      }
      print!("{}", c);
      if j<l-1 { print!(" "); } else { print!("\n"); }
    }
  }
}

fn input_i32_vals() -> std::vec::Vec<i32> {
  let mut tmp = String::new();
  io::stdin().read_line(&mut tmp).unwrap();
  tmp.trim().split(" ").map(|s| s.parse().unwrap()).collect()
}
