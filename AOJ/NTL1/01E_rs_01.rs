// https://onlinejudge.u-aizu.ac.jp/solutions/problem/NTL_1_E/review/6053669/kagemeka/Rust
pub struct Scanner<R: std::io::Read> {
  reader: R,
}

impl<R: std::io::Read> Scanner<R> {
  /// let stdin = std::io::stdin();
  /// let mut sc = Scanner::new(stdin.lock());
  pub fn new(reader: R) -> Self { Self { reader: reader } }

  pub fn scan<T: std::str::FromStr>(&mut self) -> T {
    use std::io::Read;
    self.reader.by_ref().bytes().map(|c| c.unwrap() as char)
      .skip_while(|c| c.is_whitespace())
      .take_while(|c| !c.is_whitespace())
      .collect::<String>().parse::<T>().ok().unwrap()
  }
}

// #[allow(warnings)]
fn main() {
  use std::io::Write;
  let stdin = std::io::stdin();
  let mut sc = Scanner::new(std::io::BufReader::new(stdin.lock()));
  let stdout = std::io::stdout();
  let out = &mut std::io::BufWriter::new(stdout.lock());

  let a: i64 = sc.scan();
  let b: i64 = sc.scan();
  let (g, x, y) = extgcd(a, b);
  writeln!(out, "{} {}", x, y).unwrap();
}

pub fn extgcd(a: i64, b: i64) -> (i64, i64, i64) {
  if b == 0 { return (a, 1, 0); }
  let (g, s, t) = extgcd(b, a % b);
  (g, t, s - a / b * t)
}
