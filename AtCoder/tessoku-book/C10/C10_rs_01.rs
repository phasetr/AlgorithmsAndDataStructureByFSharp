// https://atcoder.jp/contests/tessoku-book/submissions/36739189
const MOD: u64 = 1000000007;

fn pow(x: u64, e: u64) -> u64 {
   match e {
      0 => 1,
      v if v & 1 == 0 => pow(x * x % MOD, e >> 1),
      _ => x * pow(x, e - 1) % MOD
   }
}

fn main() {
   proconio::input!{w: u64}
   println!("{}", 12 * pow(7, w - 1) % MOD);
}
