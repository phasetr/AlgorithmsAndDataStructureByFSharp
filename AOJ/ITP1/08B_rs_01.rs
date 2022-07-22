// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_8_B/review/4095451/phspls/Rust
fn main() {
  loop {
    let mut num = String::new();
    std::io::stdin().read_line(&mut num).ok();
    let num: &str = num.trim();
    if num == "0" {
      break;
    } else {
      let res: u64 = num.chars().map(|s| s.to_string().parse::<u64>().unwrap()).sum::<u64>();
      println!("{}", res);
    }
  }
}
