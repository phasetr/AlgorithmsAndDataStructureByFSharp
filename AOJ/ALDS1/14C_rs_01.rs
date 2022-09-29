// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_14_C/review/5887238/toriichi/Rust
use std::io;
use std::usize;

fn main() {
  let mut buf = String::new();

  buf.clear();
  io::stdin().read_line(&mut buf).expect("error");
  let vec: Vec<&str> = buf.trim().split_whitespace().collect();
  let h: usize = vec[0].parse().unwrap();
  let w: usize = vec[1].parse().unwrap();

  let mut region: Vec<String> = vec![];

  for i in 0..h {
    buf.clear();
    io::stdin().read_line(&mut buf).expect("error");
    let vec: Vec<&str> = buf.trim().split_whitespace().collect();
    region.push(vec[0].to_string());
  }

  buf.clear();
  io::stdin().read_line(&mut buf).expect("error");
  let vec: Vec<&str> = buf.trim().split_whitespace().collect();
  let r: usize = vec[0].parse().unwrap();
  let c: usize = vec[1].parse().unwrap();

  let mut pattern: Vec<String> = vec![];

  for i in 0..r {
    buf.clear();
    io::stdin().read_line(&mut buf).expect("error");
    let vec: Vec<&str> = buf.trim().split_whitespace().collect();
    pattern.push(vec[0].to_string());
  }

  if r > h || c > w {
    return;
  }

  for y in 0..=h-r {
    for x in 0..=w-c {
      let mut found = true;
      for i in 0..r {
        if region[y+i][x..x+c] != pattern[i] {
          found = false;
          break;
        }
      }
      if found {
        println!("{} {}", y, x);
      }
    }
  }
}
