// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_5_D/review/5324114/boiler2/Rust
use std::io::*;
use std::str::FromStr;

fn rin<T: FromStr>() -> T {
  let s: Stdin = stdin();
  let s: StdinLock = s.lock();
  let s: String = s.bytes()
    .map(|c| c.expect("failed reading char") as char)
    .skip_while(|c| c.is_whitespace())
    .take_while(|c| !c.is_whitespace())
    .collect();
  s.parse().ok().expect("failed parsing")
}

fn merge_sort(a: &mut Vec<i32>, left: usize, right: usize) -> usize {
  if right - left == 1 { return 0; }

  let mid = left + (right - left) / 2;
  let mut cnt = 0;
  cnt += merge_sort(a, left, mid);
  cnt += merge_sort(a, mid, right);

  let mut buf: Vec<i32> = Vec::new();
  for i in left..mid {
    buf.push(a[i]);
  }
  for i in (mid..right).rev() {
    buf.push(a[i]);
  }

  let mut index_left = 0;
  let mut index_right = buf.len() - 1;
  for i in left..right {
    if buf[index_left] <= buf[index_right] {
      a[i] = buf[index_left];
      index_left += 1;
    } else {
      cnt += mid - left - index_left;
      a[i] = buf[index_right];
      index_right -= 1;
    }
  }
  cnt
}

fn main() {
  let n: usize = rin();
  let mut a: Vec<i32> = vec![0; n];
  for i in 0..n {
    a[i] = rin();
  }
  let cnt = merge_sort(&mut a, 0, n);
  println!("{}", cnt);
}
