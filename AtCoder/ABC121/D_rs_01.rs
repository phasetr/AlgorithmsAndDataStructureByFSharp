// https://atcoder.jp/contests/abc121/submissions/27303883
use proconio::input;

fn main() {
  input!{ a: u64, b: u64, }
  let mut ans = 0;
  for i in a..(a+4)/4*4 { ans ^= i; }
  for i in b/4*4..=b { ans ^= i; }
  println!("{}", ans);
}
