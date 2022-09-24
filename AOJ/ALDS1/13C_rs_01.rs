// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_13_C/review/5872286/toriichi/Rust
use std::io;
use std::usize;

struct Board {
  dat: [isize; 16],
  zpos: isize,
  prev: isize,
}

fn main() {
  let mut buf = String::new();

  let mut board = Board {
    dat: [0; 16],
    zpos: 0,
    prev: 100,
  };

  for r in 0..4 {
    buf.clear();
    io::stdin().read_line(&mut buf).expect("error");
    let vec: Vec<&str> = buf.trim().split_whitespace().collect();
    for c in 0..4 {
      board.dat[r * 4 + c] = vec[c].parse().unwrap();
      if board.dat[r * 4 + c] == 0 {
        board.zpos = (r * 4 + c) as isize;
      }
    }
  }

  solve(&mut board);
}

fn solve(board: &mut Board) {
  let md = get_md(board);
  // println!("{}", md);
  for limit in md..=45 {
    if dfs(board, 0, limit) {
      println!("{}", limit);
      break;
    }
  }
}

fn dfs(board: &mut Board, depth: isize, limit: isize) -> bool {
  let md = get_md(board);

  if md == 0 {
    return true;
  }

  if depth + md > limit {
    return false;
  }

  let moves = [[-1,0], [0,1], [1,0], [0,-1]];
  for i in 0..4 {
    if (board.prev - i).abs() == 2 {
      continue;
    }
    let y2 = board.zpos / 4 + moves[i as usize][0];
    let x2 = board.zpos % 4 + moves[i as usize][1];
    if x2 < 0 || 4 <= x2 || y2 < 0 || 4 <= y2 {
      continue;
    }
    let zpos2 = y2 * 4 + x2;

    let zpos_org = board.zpos;
    let prev_org = board.prev;
    board.dat[board.zpos as usize] = board.dat[zpos2 as usize];
    board.dat[zpos2 as usize] = 0;
    board.zpos = zpos2;
    board.prev = i;

    if dfs(board, depth+1, limit) {
      return true;
    }

    board.prev = prev_org;
    board.zpos = zpos_org;
    board.dat[zpos2 as usize] = board.dat[board.zpos as usize];
    board.dat[board.zpos as usize] = 0;
  }
  false
}

fn get_md(board: &Board) -> isize {
  let mut sum = 0;
  for i in 0..16 {
    let mut v = board.dat[i];
    if v != 0 {
      v -= 1;
      let dif = (v/4 - i as isize /4).abs() + (v%4 - i as isize %4).abs();
      sum += dif;
    }
  }
  sum
}
