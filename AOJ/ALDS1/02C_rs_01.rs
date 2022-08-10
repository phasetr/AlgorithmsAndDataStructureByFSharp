// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_2_C/review/4359897/orzz/Rust
use std::io::*;
type Card = [u8; 2];
fn bubble_sort(slice: &mut [Card]) {
  let mut flag = true;

  while flag {
    flag = false;

    for j in (1..slice.len()).rev() {
      if slice[j][1] < slice[j - 1][1] {
        slice.swap(j, j - 1);
        flag = true;
      }
    }
  }
}

fn selection_sort(slice: &mut [Card]) {
  for i in 0..slice.len() {
    let mut minj = i;

    for j in i..slice.len() {
      if slice[j][1] < slice[minj][1] {
        minj = j;
      }
    }
    if i != minj {
      slice.swap(i, minj);
    }
  }
}

fn output<W: Write>(out: &mut W, slice: &[Card]) {
  out.write_all(&slice[0]);

  for v in &slice[1..] {
    out.write(b" ");
    out.write_all(v);
  }
}

fn main() {
  let input = {
    let mut buf = vec![];
    stdin().read_to_end(&mut buf);
    unsafe { String::from_utf8_unchecked(buf) }
  };
  let mut lines = input.split('\n');

  let n = lines.next().unwrap().parse().unwrap();

  let mut vec_o = Vec::with_capacity(n);
  let iter = lines
    .next()
    .unwrap()
    .split(' ')
    .map(|s| unsafe { *(s.as_bytes().as_ptr() as *const [u8; 2]) });
  vec_o.extend(iter);

  let out = stdout();
  let mut out = BufWriter::new(out.lock());

  let mut vec1 = vec_o.clone();
  bubble_sort(&mut vec1);

  output(&mut out, &vec1);
  out.write_all(b"\nStable\n");

  let mut vec2 = vec_o.clone();
  selection_sort(&mut vec2);

  output(&mut out, &vec2);
  out.write_all(if vec1 == vec2 {
    b"\nStable\n"
  } else {
    b"\nNot stable\n"
  });
}
