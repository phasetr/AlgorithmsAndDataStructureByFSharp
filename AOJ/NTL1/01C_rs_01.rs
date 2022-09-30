// https://onlinejudge.u-aizu.ac.jp/solutions/problem/NTL_1_C/review/3398515/andraantariksa/Rust
fn gcd(a: u64, b: u64) -> u64 {
  if b == 0 {
    return a;
  }
  return gcd(b, a % b);
}

fn lcm(a: u64, b: u64) -> u64 {
  return a * b / gcd(a, b);
}

fn main() {
  let mut s = format!("");
  std::io::stdin().read_line(&mut s).expect("");
  s = format!("");
  std::io::stdin().read_line(&mut s).expect("");
  let v: Vec<u64> = s
    .trim()
    .split_whitespace()
    .map(|x| x.parse().expect(""))
    .collect();
  let mut least_lcm: u64 = v[0];
  for i in 1..v.len() {
    least_lcm = lcm(least_lcm, v[i]);
  }
  println!("{}", least_lcm);
}
