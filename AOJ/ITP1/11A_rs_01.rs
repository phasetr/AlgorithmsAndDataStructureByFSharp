// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_11_A/review/5508426/skyyuki/Rust
use std::convert::TryInto;
use std::error::Error;
use std::io::Read;

fn main() -> Result<(), Box<dyn Error>> {
  let mut buf = String::new();
  std::io::stdin().read_to_string(&mut buf)?;
  let mut iter = buf.split_whitespace();

  let faces: Vec<i32> = (0..6).map(|_| iter.next()?.parse().ok()).collect::<Option<_>>().ok_or("None")?;
  let roll = iter.next().ok_or("None")?.to_string();

  let mut faces: [i32; 6] = faces[..6].try_into()?;
  for s in roll.chars() {
    let [u, f, r, l, b, d] = faces;
    faces = match s {
      'N' => [f, d, r, l, u, b],
      'E' => [l, f, u, d, b, r],
      'S' => [b, u, r, l, d, f],
      'W' => [r, f, d, u, b, l],
      _ => unreachable!(),
    }
  }

  println!("{}", faces[0]);
  Ok(())
}
