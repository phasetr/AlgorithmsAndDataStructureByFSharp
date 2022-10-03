// https://onlinejudge.u-aizu.ac.jp/solutions/problem/NTL_2_A/review/5454664/keisuke213/Rust

#![allow(unused_attributes)]
/// https://github.com/hatoo/competitive-rust-snippets
#[allow(unused_imports)]
use std::cmp::{max, min, Ordering, Reverse};
#[allow(unused_imports)]
use std::collections::{BTreeMap, BTreeSet, BinaryHeap, HashMap, HashSet, VecDeque};
#[allow(unused_imports)]
use std::io::{stdin, stdout, BufWriter, Write};
#[allow(unused_imports)]
use std::iter::FromIterator;
#[allow(unused_macros)]
macro_rules ! input {(source = $ s : expr , $ ($ r : tt ) * ) => {let mut iter = $ s . split_whitespace () ; let mut next = || {iter . next () . unwrap () } ; input_inner ! {next , $ ($ r ) * } } ; ($ ($ r : tt ) * ) => {let stdin = std :: io :: stdin () ; let mut bytes = std :: io :: Read :: bytes (std :: io :: BufReader :: new (stdin . lock () ) ) ; let mut next = move || -> String {bytes . by_ref () . map (| r | r . unwrap () as char ) . skip_while (| c | c . is_whitespace () ) . take_while (| c |! c . is_whitespace () ) . collect () } ; input_inner ! {next , $ ($ r ) * } } ; }
#[allow(unused_macros)]
macro_rules ! input_inner {($ next : expr ) => {} ; ($ next : expr , ) => {} ; ($ next : expr , $ var : ident : $ t : tt $ ($ r : tt ) * ) => {let $ var = read_value ! ($ next , $ t ) ; input_inner ! {$ next $ ($ r ) * } } ; }
#[allow(unused_macros)]
macro_rules ! read_value {($ next : expr , ($ ($ t : tt ) ,* ) ) => {($ (read_value ! ($ next , $ t ) ) ,* ) } ; ($ next : expr , [$ t : tt ; $ len : expr ] ) => {(0 ..$ len ) . map (| _ | read_value ! ($ next , $ t ) ) . collect ::< Vec < _ >> () } ; ($ next : expr , chars ) => {read_value ! ($ next , String ) . chars () . collect ::< Vec < char >> () } ; ($ next : expr , usize1 ) => {read_value ! ($ next , usize ) - 1 } ; ($ next : expr , $ t : ty ) => {$ next () . parse ::<$ t > () . expect ("Parse error" ) } ; }

use std::ops::{Add,Sub,Mul,Div};
#[derive(Debug,Eq, PartialEq)]
struct BigInt{
  digits: Vec<i32>,
  is_minus : bool
}

impl BigInt {
  pub fn new(s: &str) -> Self {
    let s : Vec<char> = s.chars().collect();
    let (mut digits, mut is_minus) = if s[0] == '-' {
      (s[1..].iter().rev().map(|c| c.to_digit(10).unwrap() as i32).collect(), true)
    } else {
      (s.iter().rev().map(|c| c.to_digit(10).unwrap() as i32).collect(), false)
    };
    BigInt::_remove_leading_zero(&mut digits);
    // zero case
    if digits.len() == 1 && digits[0] == 0 {
      is_minus = false;
    }
    Self {
      digits,
      is_minus
    }
  }

  fn _remove_leading_zero(digits: &mut Vec<i32>) {
    while digits.len() > 1 && digits.last().unwrap() == &0 {
      digits.pop();
    }
  }

  pub fn to_string(&self) -> String {
    let mut vc = Vec::new();
    if self.is_minus {
      vc.push('-');
    }
    for &d in self.digits.iter().rev() {
      vc.push(std::char::from_digit(d as u32,10).unwrap());
    }
    vc.iter().collect()
  }

  fn _carry_and_fix(digits: &mut Vec<i32>) {
    let n = digits.len();
    for i in 0..n-1 {
      if digits[i] > 9 {
        let k = digits[i] / 10;
        digits[i] -= k*10;
        digits[i+1] += k;
      }
      if digits[i] < 0 {
        let k = (-digits[i] -1) / 10 +1;
        digits[i] += k*10;
        digits[i+1] -= k;
      }
    }
    let mut k = *digits.last().unwrap();
    while  k > 9 {
      k /= 10;
      *digits.last_mut().unwrap() -= k*10;
      digits.push(k);
    }
    BigInt::_remove_leading_zero(digits);
  }

  fn _cmp(self_digits: &[i32] , other_digits: &[i32]) -> std::cmp::Ordering {
    let n_self = self_digits.len();
    let n_other = other_digits.len();
    if n_self == n_other {
      for i in (0..n_self).rev() {
        if self_digits[i] != other_digits[i] {
          return self_digits[i].cmp(&other_digits[i]);
        }
      }
      Ordering::Equal
    } else {
      n_self.cmp(&n_other)
    }
  }

  fn _swap_less_case(self_digits: &mut Vec<i32>, other_digits: &mut Vec<i32>) -> bool {
    if BigInt::_cmp(&self_digits, &other_digits) == Ordering::Less {
      std::mem::swap(self_digits, other_digits);
      return true;
    }
    false
  }

  fn _add(self_digits: &[i32], other_digits: &[i32]) -> Vec<i32> {
    let n = std::cmp::max(self_digits.len(), other_digits.len());
    let mut digits = vec![0i32;n];
    for (i,&d) in self_digits.iter().enumerate() {
      digits[i] += d;
    }
    for (i,&d) in other_digits.iter().enumerate() {
      digits[i] += d;
    }
    BigInt::_carry_and_fix(&mut digits);
    digits
  }
  // a-b
  fn _sub(self_digits: &[i32], other_digits: &[i32]) -> Vec<i32> {
    let mut digits = self_digits.to_vec();
    for (i,&d) in other_digits.iter().enumerate() {
      digits[i] -= d;
    }
    BigInt::_carry_and_fix(&mut digits);
    digits
  }

  fn _mul(self_digits: &[i32] , other_digits: &[i32]) -> Vec<i32> {
    let mut digits = vec![0i32;self_digits.len()+other_digits.len()];
    for (i,&di) in self_digits.iter().enumerate() {
      for (j,&dj) in other_digits.iter().enumerate() {
        digits[i+j] += di*dj;
      }
    }
    BigInt::_carry_and_fix(&mut digits);
    digits
  }

  fn _div(lhs_digits: &[i32], rhs_digits: &[i32]) -> Vec<i32> {
    let n_lhs = lhs_digits.len();
    let n_rhs = rhs_digits.len();
    if n_lhs < n_rhs {
      return vec![0];
    }
    let mut d = n_lhs - n_rhs;
    if BigInt::_cmp(&lhs_digits[d..n_lhs], &rhs_digits) != Ordering::Less {
      d += 1;
    }
    if d == 0 {
      return vec![0];
    }
    let mut remain = lhs_digits[(d-1)..n_lhs].to_vec();
    let mut digits = vec![9i32;d];
    for i in (0..d-1).rev() {
      for j in 1..=9 {
        let x = BigInt::_mul(&rhs_digits, &vec![j]);
        if BigInt::_cmp(&x, &remain) == Ordering::Greater {
          digits[i] = j-1;
          break;
        }
      }
      let x_result = BigInt::_mul(&rhs_digits, &vec![digits[i]]);
      remain = BigInt::_sub(&remain, &x_result);
      if i >= 1 {
        remain.insert(0, lhs_digits[i-1]);
      }
    }
    digits
  }
}

impl Add for BigInt {
  type Output = Self;
  fn add(self, other: Self) -> Self {
    let (digits, mut is_minus) = if self.is_minus ^ other.is_minus {
      // a+(-b) or (-a)+b
      if BigInt::_cmp(&self.digits, &other.digits) == Ordering::Greater {
        let digits = BigInt::_sub(&self.digits, &other.digits);
        (digits, self.is_minus)
      } else {
        let digits = BigInt::_sub(&other.digits, &self.digits);
        (digits, other.is_minus)
      }
    } else {
      // a+b or (-a)+(-b)
      let digits = BigInt::_add(&self.digits, &other.digits);
      (digits, self.is_minus)
    };
    // zero case
    if digits.len() == 1 && digits[0] == 0 {
      is_minus = false;
    }
    Self {digits, is_minus}
  }
}

impl Sub for BigInt {
  type Output = Self;
  fn sub(self, other: Self) -> Self {
    let (digits, mut is_minus) = if self.is_minus ^ other.is_minus {
      // a-(-b) or (-a)-b
      let digits = BigInt::_add(&self.digits, &other.digits);
      (digits, self.is_minus)
    } else {
      // a-b or (-a)-(-b)
      if BigInt::_cmp(&self.digits, &other.digits) == Ordering::Greater {
        let digits = BigInt::_sub(&self.digits, &other.digits);
        (digits, self.is_minus)
      } else {
        let digits = BigInt::_sub(&other.digits, &self.digits);
        (digits, other.is_minus)
      }
    };
    // zero case
    if digits.len() == 1 && digits[0] == 0 {
      is_minus = false;
    }
    Self {digits, is_minus}
  }
}

impl Mul for BigInt {
  type Output = Self;
  fn mul(self, other: Self) -> Self {
    let mut digits = BigInt::_mul(&self.digits, &other.digits);
    let mut is_minus = self.is_minus ^ other.is_minus;
    // zero case
    if digits.len() == 1 && digits[0] == 0 {
      is_minus = false;
    }
    Self {digits, is_minus}
  }
}

impl Div for BigInt {
  type Output = Self;
  fn div(self, other: Self) -> Self {
    let mut lhs_digits = self.digits;
    let mut rhs_digits = other.digits;
    let digits = BigInt::_div(&lhs_digits, &rhs_digits);
    Self {digits, is_minus: self.is_minus ^ other.is_minus}
  }
}

impl PartialOrd for BigInt {
  fn partial_cmp(&self, other: &Self) -> Option<Ordering> {
    Some(self.cmp(other))
  }
}

impl Ord for BigInt {
  fn cmp(&self, other: &Self) -> Ordering {
    if self.is_minus ^ other.is_minus {
      if self.is_minus {
        Ordering::Less
      } else {
        Ordering::Greater
      }
    } else {
      let ord = BigInt::_cmp(&self.digits,&other.digits);
      if self.is_minus {
        if ord == Ordering::Greater {
          Ordering::Less
        } else if ord == Ordering::Less {
          Ordering::Greater
        } else {
          Ordering::Equal
        }
      } else {
        ord
      }
    }
  }
}


fn main() {
  input!{
    a: String,
    b: String
  };
  let a = BigInt::new(&a);
  let b = BigInt::new(&b);
  let c = a + b;
  println!("{}",c.to_string());
}
