// https://atcoder.jp/contests/tessoku-book/submissions/35755000
#![allow(non_snake_case)]
use proconio::{fastout, input};

struct SegmentTree {
    size: usize,
    tree: Vec<usize>,
}

impl SegmentTree {
    pub fn new(n: usize) -> Self {
        let mut size = 1;
        while size < n {
            size *= 2;
        }
        Self {
            size,
            tree: vec![0; 2 * size + 1],
        }
    }

    pub fn update(&mut self, pos: usize, x: usize) {
        let mut pos = pos + self.size - 1;
        self.tree[pos] = x;
        while pos >= 2 {
            pos /= 2;
            self.tree[pos] = std::cmp::max(self.tree[pos * 2], self.tree[pos * 2 + 1]);
        }
    }

    pub fn query(&self, l: usize, r: usize, a: usize, b: usize, u: usize) -> i64 {
        if r <= a || b <= l {
            return -10000000000;
        }
        if l <= a && b <= r {
            return self.tree[u] as i64;
        }

        let m = (a + b) / 2;
        let answer_l = self.query(l, r, a, m, u * 2);
        let answer_r = self.query(l, r, m, b, u * 2 + 1);
        std::cmp::max(answer_l, answer_r)
    }
}

#[fastout]
fn main() {
    input! {N: usize, Q: usize}

    let mut st = SegmentTree::new(N);
    for _ in 1..=Q {
        input! {mode: usize}
        if mode == 1 {
            input! {pos: usize, x: usize}
            st.update(pos, x);
        } else if mode == 2 {
            input! {l: usize, r: usize}
            println!("{}", st.query(l, r, 1, st.size + 1, 1));
        }
    }
}
