// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_13_B/review/5033132/ei1710/Rust
pub struct Scanner {
  idx: usize,
  buf: Vec<String>,
}

impl Scanner {
  pub fn new<T: std::io::Read>(inf: &mut T) -> Scanner {
    Self {
      idx:0,
      buf: {
        let mut s = String::new();
        inf.read_to_string(&mut s).expect("I/O error");
        s.split_whitespace().map(|x| x.to_owned()).collect()
      },
    }
  }

  pub fn read<T: std::str::FromStr> (&mut self) -> T
  where
    <T as std::str::FromStr>::Err: std::fmt::Debug,
  {
    if self.empty() {
      panic!("reached the end of input")
    }
    let ret = self.buf[self.idx].parse::<T>().expect("parse error");
    self.idx += 1;
    return ret;
  }

  pub fn empty(&self) -> bool {
    return self.idx >= self.buf.len();
  }
}

fn main() {
  let mut sc = Scanner::new(&mut std::io::stdin());

  let mut mp = [[0u8; 3]; 3];

  for i in 0..3 {
    for j in 0..3 {
      mp[i][j] = sc.read();
    }
  }

  let mut st = std::collections::HashSet::new();
  st.insert(mp.clone());
  let mut que = std::collections::VecDeque::new();
  que.push_back((mp.clone(), 0));

  let pos0 = |mp: &[[u8; 3]; 3]| {
    for i in 0..3 {
      for j in 0..3 {
        if mp[i][j] == 0 {
          return (i, j);
        }
      }
    }
    return (0, 0);
  };

  let goal = [[1, 2, 3], [4, 5, 6], [7, 8, 0]];
  let dx = [1, 0, -1, 0];
  let dy = [0, 1, 0, -1];
  let ran = 0..3;
  while !que.is_empty() {
    let (mut mp, cost) = que.pop_front().unwrap();
    let (sy, sx) = pos0(&mp);

    if goal == mp {
      println!("{}", cost);
      return;
    }

    for i in 0..4 {
      let y = sy as i32 + dy[i];
      let x = sx as i32 + dx[i];

      if ran.contains(&y) && ran.contains(&x) {
        let y = y as usize;
        let x = x as usize;

        mp[sy][sx] = mp[y][x];
        mp[y][x] = 0;

        if !st.contains(&mp) {
          st.insert(mp.clone());
          que.push_back((mp.clone(), cost + 1));
        }

        mp[y][x] = mp[sy][sx];
        mp[sy][sx] = 0;
      }
    }
  }
}
