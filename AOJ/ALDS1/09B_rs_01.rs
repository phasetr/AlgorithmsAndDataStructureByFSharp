// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_9_B/review/6137594/enoyo/Rust
use std::io;

const ROOT_PARENT_KEY:i32 = 1<<31;

fn max_heapify(heap:&mut Vec<i32>,len:usize,idx:usize) {
  let l = idx*2;
  let r = idx*2+1;
  let mut largest = idx;

  if l<=len && heap[l]>heap[largest] {
    largest=l;
  }
  if r<=len && heap[r]>heap[largest] {
    largest=r;
  }
  if largest!=idx {
    heap.swap(idx,largest);
    max_heapify(heap,len,largest);
  }
}

fn main() {
  let h:usize = read_line().trim().parse().unwrap();
  let mut heap:Vec<i32> = read_line()
    .trim()
    .splitn(h,' ')
    .map(|s| s.parse().unwrap())
    .collect();
  let len = heap.len();
  heap.insert(0,ROOT_PARENT_KEY);

  let mut idx = len/2;
  while idx>0 {
    max_heapify(&mut heap,len,idx);
    idx -= 1;
  }

  for i in 1..=len {
    print!(" {}",heap[i]);
  }
  println!();
}

fn read_line() -> String {
  let mut buf = String::new();
  io::stdin().read_line(&mut buf).ok();
  buf
}
