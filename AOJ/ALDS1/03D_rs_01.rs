// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_3_D/review/4348343/orzz/Rust
use std::fmt::Write;
use std::io::*;

fn main() {
  let input = {
    let mut buf = vec![];
    stdin().read_to_end(&mut buf);
    buf.pop();
    unsafe { String::from_utf8_unchecked(buf) }
  };

  let mut l_arr = vec![];
  let mut stack = vec![];

  for (i, ch) in input.bytes().enumerate() {
    match ch {
      b'\\' => {
        stack.push((l_arr.len(), i));
      }
      b'/' => {
        if let Some((k, j)) = stack.pop() {
          if l_arr.len() < k + 1 {
            l_arr.push(i - j);
          } else {
            l_arr[k] += i - j;

            if k + 1 < l_arr.len() {
              let sum = l_arr.drain(k + 1..).sum::<usize>();
              l_arr[k] += sum;
            }
          }
        }
      }
      _ => {}
    }
  }

  let mut res = format!("{}\n", l_arr.iter().sum::<usize>());

  write!(res, "{}", l_arr.len());
  for l in l_arr {
    write!(res, " {}", l);
  }
  println!("{}", res);
}
