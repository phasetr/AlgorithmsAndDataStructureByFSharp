// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_11_C/review/5508547/skyyuki/Rust
use std::collections::BTreeSet;
use std::io::Read;
use std::convert::TryInto;
use std::error::Error;

fn main() -> Result<(), Box<dyn Error>> {
  let mut buf = String::new();
  std::io::stdin().read_to_string(&mut buf)?;
  let mut iter = buf.split_whitespace();

  let mut faces: [i32; 6] = (0..6)
    .map(|_| iter.next()?.parse().ok())
    .collect::<Option<Vec<i32>>>()
    .ok_or("None")?[..6]
    .try_into()?;

  let dice: [i32; 6] = (0..6)
    .map(|_| iter.next()?.parse().ok())
    .collect::<Option<Vec<i32>>>()
    .ok_or("None")?[..6]
    .try_into()?;

  let mut map = BTreeSet::new();

  for i in 0..6 {
    for _ in 0..4 {
      let [u, f, r, l, b, d] = faces;
      map.insert(faces);
      faces = [u, r, b, f, l, d];
    }
    let [u, f, r, l, b, d] = faces;
    faces = if i & 1 == 0 {
      [b, u, r, l, d, f]
    } else {
      [l, f, u, d, b, r]
    }
  }

  println!("{}", if map.contains(&dice) {"Yes"} else {"No"});

  Ok(())
}
