// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_8_A/review/5209077/boiler21/Rust
use std::cell::RefCell;
use std::rc::Rc;

enum Tree {
  Node { key: i64, left: Rc<RefCell<Tree>>, right: Rc<RefCell<Tree>> },
  Nil
}

impl Tree {
  fn new() -> Tree {
    Tree::Nil
  }

  fn insert(&mut self, k: i64) {
    match *self {
      Tree::Nil => {
        *self = Tree::Node {
          key: k,
          left: Rc::new(RefCell::new(Tree::Nil)),
          right: Rc::new(RefCell::new(Tree::Nil)),
        }
      },
      Tree::Node { ref mut key, ref mut left, ref mut right } => {
        if k < *key {
          left.borrow_mut().insert(k);
        } else {
          right.borrow_mut().insert(k);
        }
      }
    }
  }

  fn inorder(&self) {
    match *self {
      Tree::Nil => {},
      Tree::Node { ref key, ref left, ref right } => {
        left.borrow().inorder();
        print!(" {}", key);
        right.borrow().inorder();
      }
    }
  }

  fn preorder(&self) {
    match *self {
      Tree::Nil => {},
      Tree::Node { ref key, ref left, ref right } => {
        print!(" {}", key);
        left.borrow().preorder();
        right.borrow().preorder();
      }
    }
  }
}

fn main() {
  let mut s = String::new();
  std::io::stdin().read_line(&mut s).ok();
  let n: usize = s.trim().parse().unwrap();

  let mut tree = Tree::new();

  for _ in 0..n {
    s.clear();
    std::io::stdin().read_line(&mut s).ok();
    let mut it = s.split_whitespace();
    let com = it.next().unwrap();
    if com == "insert" {
      let x: i64 = it.next().unwrap().parse().unwrap();
      tree.insert(x);
    } else if com == "print" {
      tree.inorder();
      println!();
      tree.preorder();
      println!();
    }
  }
}
