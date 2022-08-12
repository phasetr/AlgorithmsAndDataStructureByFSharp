// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_3_A/review/4347506/orzz/Rust
use std::io::*;

fn main() {
  let input = {
    let mut buf = vec![];
    stdin().read_to_end(&mut buf);
    buf.pop();
    unsafe { String::from_utf8_unchecked(buf) }
  };

  let mut stack: Vec<i32> = vec![];

  for token in input.split(' ') {
    match token {
      "+" => {
        let b = stack.pop().unwrap();
        *stack.last_mut().unwrap() += b;
      },
      "-" => {
        let b = stack.pop().unwrap();
        *stack.last_mut().unwrap() -= b;
      },
      "*" => {
        let b = stack.pop().unwrap();
        *stack.last_mut().unwrap() *= b;
      },
      n => {
        stack.push(n.parse().unwrap());
      }
    }
  }

  println!("{}", stack[0]);
}
