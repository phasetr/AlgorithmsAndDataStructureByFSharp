// https://atcoder.jp/contests/abc088/submissions/16270216
use proconio::{input, marker::Chars};
use std::collections::VecDeque;

fn main() {
    input! {
        h: isize, w: isize,
        mut field: [Chars; h],
    }

    let mut white_count = 0;
    for line in &field {
        for &c in line {
            if c == '.' { white_count += 1 };
        }
    }

    let mut deque = VecDeque::new();
    deque.push_back((0, 0, 1));
    field[0][0] = '#';
    while let Some((i, j, cost)) = deque.pop_front() {
        if i == h-1 && j == w-1 {
            println!("{}", white_count - cost);
            return;
        }
        for &(di, dj) in [(-1, 0), (0, -1), (1, 0), (0, 1)].iter() {
            let (i1, j1) = (i+di, j+dj);
            if i1 < 0 || j1 < 0 || i1 >= h || j1 >= w { continue };
            if field[i1 as usize][j1 as usize] == '.' {
                field[i1 as usize][j1 as usize] = '#';
                deque.push_back((i1, j1, cost+1));
            }
        }
    }
    println!("{}", -1);
}
