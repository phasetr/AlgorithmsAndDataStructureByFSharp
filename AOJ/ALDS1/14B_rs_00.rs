fn read<T: std::str::FromStr>() -> T {
  let mut s = String::new();
  std::io::stdin().read_line(&mut s).ok();
  s.trim().parse().ok().unwrap()
}
fn main() {
  let t: String = read();
  let p: String = read();
  let n = t.len();
  let d = p.len();
  if d > n {
    return;
  }
  for i in 0..n-d+1 {
    if t[i..(i+d)] == p {
      println!("{}", i);
    }
  }
}
