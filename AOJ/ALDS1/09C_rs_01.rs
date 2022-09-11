// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_9_C/review/6138210/enoyo/Rust
use std::io;

const INFINITY:i32 = 0x7FFFFFFF;

struct Heap {
  tree: Vec<i32>,
  size:usize,
}

impl Heap {
  fn new() -> Heap {
    let mut tree:Vec<i32> = Vec::new();
    tree.push(INFINITY);
    Heap {
      tree,
      size:0,
    }
  }

  fn insert(&mut self,key:i32) {
    self.size += 1;
    self.tree.push(key);
    let mut idx = self.size;
    loop {
      if idx<=1 {
        break;
      }
      let p_idx = idx/2;
      if let Some(&p_key) = self.tree.get(p_idx) {
        if p_key<key {
          self.tree.swap(p_idx,idx);
          idx = p_idx;
        } else {
          break;
        }

      } else {
        break;
      }
    }
  }

  fn extract(&mut self) -> i32 {
    if self.size==0 {
      return INFINITY;
    }
    let max = self.tree[1];
    self.tree[1] = self.tree[self.size];
    self.tree.pop();
    self.size -= 1;
    self.max_heapify(1);
    max
  }

  fn max_heapify(&mut self,idx:usize) {
    let l = idx*2;
    let r = idx*2+1;
    let mut largest = idx;
    if self.size<1 {
      return;
    }

    if l<=self.size && self.tree[l]>self.tree[largest] {
      largest=l;
    }
    if r<=self.size && self.tree[r]>self.tree[largest] {
      largest=r;
    }
    if largest!=idx {
      self.tree.swap(idx,largest);
      self.max_heapify(largest);
    }
  }
}

fn main() {
  let mut heap = Heap::new();
  loop {
    let order:Vec<i32> = read_line()
      .trim()
      .split_whitespace()
      .map(|s| {
        match s {
          "insert" => 1,
          "extract" => 2,
          "end" => 0,
          _ => s.parse().unwrap(),
        }
      })
      .collect();

    match order[0] {
      0 => break,
      1 => heap.insert(order[1]),
      2 => println!("{}",heap.extract()),
      _ => {}
    }
  }
}

fn read_line() -> String {
  let mut buf = String::new();
  io::stdin().read_line(&mut buf).ok();
  buf
}
