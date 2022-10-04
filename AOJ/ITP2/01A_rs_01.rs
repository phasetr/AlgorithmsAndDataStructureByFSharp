// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP2_1_A/review/5049762/y61mpnl/Rust
fn readi() -> Vec<i32> {
  let mut s = String::new();
  std::io::stdin().read_line(&mut s).unwrap();
  s.split_whitespace().map(|x| x.parse::<i32>().unwrap()).collect()
}


fn main() {
  let mut q = readi()[0];

  let mut stack: Vec<i32> = Vec::new();

  while q>0 {
    let query = readi();
    match query[0] {
      0 => stack.push(query[1]),
      1 => println!("{}", stack[query[1] as usize]),
      2 => { stack.pop(); },
      _ => ()
    };
    q -= 1;
  }
}
