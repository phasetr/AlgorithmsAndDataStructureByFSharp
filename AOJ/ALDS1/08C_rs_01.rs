// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_8_C/review/5571466/sandbox0436/Rust
use std::{env::current_exe, io::Read};
#[derive(Debug)]
struct Node {
  key: isize,
  left: Tree,
  right: Tree,
}
impl Node {
  fn new(value: isize) -> Self {
    Node {
      key: value,
      left: Tree(None),
      right: Tree(None),
    }
  }
}

#[derive(Debug)]
struct Tree(Option<Box<Node>>);

impl Tree {
  fn insert(&mut self, value: isize) {
    let mut current = self;

    while let Some(ref mut node) = current.0 {
      if value < node.key {
        current = &mut node.left;
      } else {
        current = &mut node.right;
      }
    }
    current.0 = Some(Box::new(Node::new(value)));
  }

  fn delete(&mut self, value: &isize) {
    let mut current = self;
    while let Some(ref mut node) = current.0 {
      if *value < node.key {
        current = &mut current.0.as_mut().unwrap().left;
      } else if *value > node.key {
        current = &mut current.0.as_mut().unwrap().right;
      } else {
        match (node.left.0.as_mut(), node.right.0.as_mut()) {
          (None, None) => current.0 = None,
          (None, Some(_)) => current.0 = node.right.0.take(),
          (Some(_), None) => current.0 = node.left.0.take(),
          (Some(_), Some(_)) => {
            current.0.as_mut().unwrap().key = node.right.extract_min().unwrap();
          }
        }
      }
    }
  }

  fn find(&self, value: &isize) -> bool {
    let mut current = self;
    while let Some(node) = &current.0 {
      if *value == node.key {
        return true;
      }
      else if *value < node.key {
        current = &current.0.as_ref().unwrap().left;
      } else {
        current = &current.0.as_ref().unwrap().right;
      }
    }
    false
  }

  fn extract_min(&mut self) -> Option<isize> {
    let mut node = None;
    if self.0.is_some() {
      let mut current = self;
      while current.0.as_ref().unwrap().left.0.is_some() {
        current = &mut current.0.as_mut().unwrap().left;
      }
      let temp = current.0.take().unwrap();
      node = Some(temp.key);
      current.0 = temp.right.0
    }
    node
  }

  fn in_parse(&self, res: &mut Vec<String>) {
    self.0.as_ref().map(|x| x.left.in_parse(res));
    if let Some(node) = self.0.as_ref() {
      res.push(node.key.to_string());
    }
    self.0.as_ref().map(|x| x.right.in_parse(res));
  }

  fn pre_parse(&self, res: &mut Vec<String>) {
    if let Some(node) = self.0.as_ref() {
      res.push(node.key.to_string());
      node.left.pre_parse(res);
      node.right.pre_parse(res);
    }
  }
}

#[derive(Debug)]
pub struct BST {
  root: Tree,
}
impl BST {
  pub fn new() -> Self {
    BST {root: Tree(None)}
  }

  pub fn insert(&mut self, value: isize) {
    self.root.insert(value);
  }

  pub fn find(&self, value: &isize) {
    println!("{}", if self.root.find(value) {"yes"} else {"no"});
  }

  pub fn delete(&mut self, value: &isize) {
    self.root.delete(value);
  }

  pub fn in_parse(&self) -> String {
    let mut res = Vec::new();
    self.root.in_parse(&mut res);
    res.join(" ")
  }

  pub fn pre_parse(&self) -> String {
    let mut res = Vec::new();
    self.root.pre_parse(&mut res);
    res.join(" ")
  }

  pub fn print(&self) {
    println!(" {}", self.in_parse());
    println!(" {}", self.pre_parse());
  }
}

fn main() {
  let mut buf = String::new();
  std::io::stdin().read_to_string(&mut buf).unwrap();
  let mut commands = buf.split_whitespace().skip(1);

  let mut bst = BST::new();

  while let Some(com) = commands.next() {
    match com {
      "print" => {
        bst.print();
      }
      c => {
        let v = commands.next().unwrap().trim().parse::<isize>().unwrap();
        match c {
          "insert" => bst.insert(v),
          "find" => bst.find(&v),
          "delete" => bst.delete(&v),
          _ => panic!("command error")
        }
      }
    }
  }
}

#[test]
fn test() {
  let mut bst = BST::new();
  bst.insert(10);
  bst.insert(1);
  bst.insert(15);
  bst.delete(&10);
  println!("{:?}",  bst);
}
