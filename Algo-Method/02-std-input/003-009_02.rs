// https://algo-method.com/submissions/258668
use std::io;

fn main() {
  let mut n = String::new();
  io::stdin().read_line(&mut n);
  let n: i32 = n.trim().parse().unwrap();

  let mut ans: Vec<char> = Vec::new();
  for _ in 0..n {
    let mut s = String::new();
    io::stdin().read_line(&mut s);
    ans.push(s.trim().chars().collect::<Vec<char>>()[0])
  }
  println!("{}", ans.into_iter().collect::<String>());
}
