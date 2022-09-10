// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_8_D/review/4892443/ei1710/Rust
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

pub struct Node {
  val: i32,
  priority: i32,
  left: usize,
  right: usize,
}
impl Node {
  pub fn new(val: i32, p: i32) -> Self {
    Self {
      val: val,
      priority: p,
      left: 0,
      right: 0,
    }
  }
}

pub struct Tree {
  nodes: Vec<Node>,
  addr: Vec<usize>,
  idx: usize,
  root: usize,
}

impl Tree {
  pub fn new(n: usize) -> Self {
    Self {
      nodes: (0..=n).map(|_| Node::new(0, 0)).collect(),
      addr: (0..=n).map(|i| i).collect(),
      idx: 1,
      root: 0,
    }
  }
}
impl Tree {
  pub fn insert(&mut self, val: i32, p: i32) {
    self.root = self.__insert(self.root, val, p);
  }
  fn __insert(&mut self, uid: usize, val: i32, p: i32) -> usize {
    if uid == 0 {
      let vid = self.addr[self.idx];
      self.idx += 1;
      self.nodes[vid].left = 0;
      self.nodes[vid].right = 0;
      self.nodes[vid].priority = p;
      self.nodes[vid].val = val;
      return vid;
    }
    if val == self.nodes[uid].val {
      return uid;
    }

    if val < self.nodes[uid].val {
      self.nodes[uid].left = self.__insert(self.nodes[uid].left, val, p);
      if self.nodes[uid].priority < self.nodes[self.nodes[uid].left].priority {
        return self.right_rotate(uid);
      }
    }
    else {
      self.nodes[uid].right = self.__insert(self.nodes[uid].right, val, p);
      if self.nodes[uid].priority < self.nodes[self.nodes[uid].right].priority {
        return self.left_rotate(uid);
      }
    }
    return uid;
  }

  pub fn find(&self, val: i32) -> bool {
    let mut uid = self.root;
    while uid != 0 {
      match val.cmp(&self.nodes[uid].val) {
        std::cmp::Ordering::Less => uid = self.nodes[uid].left,
        std::cmp::Ordering::Greater => uid = self.nodes[uid].right,
        std::cmp::Ordering::Equal => return true,
      }
    }

    return false;
  }

  pub fn remove(&mut self, val: i32) {
    self.root = self._remove(self.root, val);
  }
  fn _remove(&mut self, uid: usize, val: i32) -> usize {
    if uid == 0 {
      return 0;
    }
    if val < self.nodes[uid].val {
      self.nodes[uid].left = self._remove(self.nodes[uid].left, val);
    }
    else if val > self.nodes[uid].val {
      self.nodes[uid].right = self._remove(self.nodes[uid].right, val);
    }
    else {
      return self.__remove(uid, val);
    }
    return uid;
  }
  fn __remove(&mut self, mut uid: usize, val: i32) -> usize {
    if self.nodes[uid].left == 0 && self.nodes[uid].right == 0 {
      self.idx -= 1;
      self.addr[self.idx] = uid;
      return 0;
    }
    else if self.nodes[uid].left == 0 {
      uid = self.left_rotate(uid);
    }
    else if self.nodes[uid].right == 0 {
      uid = self.right_rotate(uid);
    }
    else {
      if self.nodes[self.nodes[uid].left].priority > self.nodes[self.nodes[uid].right].priority {
        uid = self.right_rotate(uid);
      }
      else {
        uid = self.left_rotate(uid);
      }
    }
    return self._remove(uid, val);
  }
}

impl Tree {
  fn right_rotate(&mut self, uid: usize) -> usize {
    let s = self.nodes[uid].left;
    self.nodes[uid].left = self.nodes[s].right;
    self.nodes[s].right = uid;
    return s;
  }
  fn left_rotate(&mut self, uid: usize) -> usize {
    let s = self.nodes[uid].right;
    self.nodes[uid].right = self.nodes[s].left;
    self.nodes[s].left = uid;
    return s;
  }
}

impl Tree {
  fn print_preorder_inner(&self, uid: usize) {
    if uid == 0 { return; }
    print!(" {}", self.nodes[uid].val);
    self.print_preorder_inner(self.nodes[uid].left);
    self.print_preorder_inner(self.nodes[uid].right);
  }
  pub fn print_preorder(&self) {
    self.print_preorder_inner(self.root);
  }

  fn print_inorder_inner(&self, uid: usize) {
    if uid == 0 { return; }
    self.print_inorder_inner(self.nodes[uid].left);
    print!(" {}", self.nodes[uid].val);
    self.print_inorder_inner(self.nodes[uid].right);
  }
  pub fn print_inorder(&self) {
    self.print_inorder_inner(self.root);
  }
}

fn main() {
  let mut sc = Scanner::new(&mut std::io::stdin());
  let q: usize = sc.read();
  let mut t = Tree::new(q);

  for _ in 0..q {
    let str = sc.read::<String>();

    if str.eq("insert") {
      let val: i32 = sc.read();
      let p: i32 = sc.read();
      t.insert(val, p);
    }
    else if str.eq("find") {
      let val: i32 = sc.read();
      println!("{}", if t.find(val) { "yes" } else { "no" });
    }
    else if str.eq("delete") {
      let val: i32 = sc.read();
      t.remove(val);
    }
    else if str.eq("print") {
      t.print_inorder();
      print!("\n");
      t.print_preorder();
      print!("\n");
    }
  }
}
