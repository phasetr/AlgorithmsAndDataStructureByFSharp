// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_14_A/review/5595201/sandbox0436/Rust
fn main() {
  let mut buf = String::new();
  std::io::stdin().read_line(&mut buf).unwrap();
  std::io::stdin().read_line(&mut buf).unwrap();
  let xs: Vec<&str> = buf.lines().collect();
  let res = solve(xs[0], xs[1]);
  for n in res {
    println!("{}", n);
  }
}

fn solve(t: &str, p: &str) -> Vec<usize> {
  let t: Vec<char> = t.chars().collect();
  let p: Vec<char> = p.chars().collect();
  let mut res = Vec::new();
  if t.len() < p.len() {
    return res;
  }
  for i in 0..=(t.len() - p.len()) {
    if t[i..(i + p.len())] == p[..] {
      res.push(i);
    }
  }
  res
}
