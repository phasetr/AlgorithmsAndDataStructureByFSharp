// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_7_C/review/2748796/enji/Rust
use std::io::BufRead;

fn main() {
  let stdin = std::io::stdin();
  let mut buf = String::new();
  stdin.read_line(&mut buf).unwrap();

  let mut ite1 = buf.trim().split_whitespace()
    .map(|x| x.parse::<usize>().unwrap());

  let r = ite1.next().unwrap();
  let c = ite1.next().unwrap();

  let sums = &mut vec![0; c + 1];

  for line in stdin.lock().lines() {
    let line = line.unwrap();

    let vec = line.trim().split_whitespace()
      .map(|x| x.parse().unwrap())
      .collect::<Vec<i32>>();

    for i in 0..c {
      sums[i] += vec[i];
      print!("{} ", vec[i]);
    }

    let sum = vec.iter().sum::<i32>();
    sums[c] += sum;
    println!("{}", sum);
  }

  println!("{}", sums.iter().map(|x| x.to_string()).collect::<Vec<_>>().join(" "));
}
