// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_3_C/review/4114460/phspls/Rust
use std::collections::VecDeque;

fn main() {
  let mut n = String::new();
  std::io::stdin().read_line(&mut n).ok();
  let n: usize = n.trim().parse::<usize>().unwrap();
  let mut result: VecDeque<u32> = VecDeque::new();
  for _ in 0..n {
    let mut c_v = String::new();
    std::io::stdin().read_line(&mut c_v).ok();
    let command_val: Vec<String> = c_v.trim().split_whitespace().map(|a| a.to_string()).collect();
    match command_val[0].as_str() {
      "insert" => {
        let v = command_val[1].to_owned();
        result.push_front(v.parse::<u32>().unwrap());
      },
      "delete" => {
        let mut index = result.len();
        for i in 0..result.len() {
          if result[i] == command_val[1].parse::<u32>().unwrap() {
            index = i;
            break;
          }
        }
        if index < result.len() {
          result.remove(index);
        }
      },
      "deleteFirst" => { result.pop_front(); },
      "deleteLast" => { result.pop_back(); },
      _ => {
        println!("insert: {:?} {:?}", command_val, result);
      },
    }
  }
  println!("{}", result.iter().map(|i| i.to_string()).collect::<Vec<String>>().join(" "));
}
