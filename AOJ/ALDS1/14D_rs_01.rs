// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_14_D/review/4884762/regonn/Rust
use std::io::*;
use std::str::FromStr;

fn read<T: FromStr>() -> T {
  let stdin = stdin();
  let stdin = stdin.lock();
  let token: String = stdin
    .bytes()
    .map(|c| c.expect("failed to read char") as char)
    .skip_while(|c| c.is_whitespace())
    .take_while(|c| !c.is_whitespace())
    .collect();
  token.parse().ok().expect("failed to parse token")
}

fn gen_suffix_array(a: &Vec<usize>) -> Vec<usize> {
  let mut s = a.clone();
  for s in &mut s {
    *s += 1;
  }
  s.push(0);
  let n = s.len();
  let m = s.iter().max().unwrap() + 1;
  // k = 0
  let mut cnt = vec![0; m];
  let mut p = vec![0; n];
  let mut c = vec![0; n];
  for s in &s {
    cnt[*s] += 1;
  }
  for i in 1..m {
    cnt[i] += cnt[i - 1];
  }
  for i in 0..n {
    let c = s[i];
    cnt[c] -= 1;
    p[cnt[c]] = i;
  }
  c[p[0]] = 0;
  let mut kind = 1;
  for i in 1..n {
    if s[p[i]] != s[p[i - 1]] {
      kind += 1;
    }
    c[p[i]] = kind - 1;
  }
  let mut k = 1;
  while k < n {
    let mut next_p = vec![0; n];
    for i in 0..n {
      next_p[i] = (p[i] + n - k) % n;
    }
    let mut cnt = vec![0; kind];
    for &p in &next_p {
      cnt[c[p]] += 1;
    }
    for i in 1..kind {
      cnt[i] += cnt[i - 1];
    }
    for &pn in next_p.iter().rev() {
      let k = c[pn];
      cnt[k] -= 1;
      p[cnt[k]] = pn;
    }
    let mut next_c = vec![0; n];
    next_c[p[0]] = 0;
    kind = 1;
    for i in 1..n {
      let prev = (c[p[i - 1]], c[(p[i - 1] + k) % n]);
      let cur = (c[p[i]], c[(p[i] + k) % n]);
      if prev != cur {
        kind += 1;
      }
      next_c[p[i]] = kind - 1;
    }
    c = next_c;
    k <<= 1;
  }
  p
}

use std::io::Write;

fn convert(c: char) -> usize {
  if '0' <= c && c <= '9' {
    c.to_digit(10).unwrap() as usize
  } else if 'a' <= c && c <= 'z' {
    c as usize - 'a' as usize + 10
  } else {
    c as usize - 'A' as usize + 36
  }
}

fn main() {
  let out = std::io::stdout();
  let mut out = std::io::BufWriter::new(out.lock());

  let line_string: String = read();
  let s: Vec<char> = line_string.chars().collect();
  let q: usize = read();

  let mut a: Vec<Vec<char>> = vec![vec![]; q];

  for i in 0..q {
    let line_string: String = read();
    let chars: Vec<char> = line_string.chars().collect();
    a[i] = chars;
  }

  let s_map: Vec<usize> = s.into_iter().map(convert).collect();
  let su = gen_suffix_array(&s_map);
  let s = s_map;
  for a in a {
    let a: Vec<usize> = a.into_iter().map(convert).collect();
    let mut l = 0;
    let mut r = su.len() - 1;
    while r - l > 1 {
      let m = (l + r) / 2;
      if *a.as_slice() <= s[su[m]..] {
        r = m;
      } else {
        l = m;
      }
    }
    let ans = if s.len() - su[r] >= a.len() && *a.as_slice() == s[su[r]..(su[r] + a.len())] {
      1
    } else {
      0
    };
    writeln!(out, "{}", ans).unwrap();
  }
}
