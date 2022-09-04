// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_7_B/review/4985544/sandbox0436/Rust
use std::io::Read;
use std::cmp::max;
#[derive(Debug)]
struct Node {
  id: isize,
  parent: isize,
  sibling: isize,
  degree: isize,
  left: isize,
  right: isize,
  depth: isize,
  height: isize,
}
impl Node {
  fn new(n: isize) -> Self {
    Self {
      id: n,
      parent: -1,
      sibling: -1,
      degree: 0,
      left: -1,
      right: -1,
      depth: 0,
      height: -1,
    }
  }
}
fn main() {
  let mut buf = String::new();
  std::io::stdin().read_to_string(&mut buf).unwrap();
  let mut iter = buf.split_whitespace();
  let n = iter.next().unwrap().parse().unwrap();

  let mut tree: Vec<Node> = (0..n).map(|x| Node::new(x)).collect();

  for _ in 0..n {
    let id= iter.next().unwrap().parse().unwrap();
    let left= iter.next().unwrap().parse().unwrap();
    let right= iter.next().unwrap().parse().unwrap();

    tree[id as usize].left = left;
    tree[id as usize].right = right;
    if left != -1 {
      tree[left as usize].parent = id;
      tree[left as usize].sibling = right;
      tree[id as usize].degree += 1;
    }
    if right != -1 {
      tree[right as usize].parent = id;
      tree[right as usize].sibling = left;
      tree[id as usize].degree += 1;
    }
  }

  let root_id = tree.iter()
    .find(|&x| x.parent == -1).unwrap().id as usize;

  set_depth(&mut tree, root_id, 0);
  set_height(&mut tree, root_id);
  print_tree(&tree);
}

fn set_depth(tree: &mut [Node], id: usize, depth: isize) {
  tree[id].depth = depth;
  let left_id = tree[id].left;
  let right_id = tree[id].right;

  if left_id != -1 {
    set_depth(tree, left_id as usize, depth + 1)
  }
  if right_id != -1 {
    set_depth(tree, right_id as usize, depth + 1)
  }
}

fn set_height(tree: &mut [Node], id: usize) -> isize{
  let mut h1 = 0;
  let mut h2 = 0;
  if tree[id].left != -1 {
    h1 = set_height(tree, tree[id].left as usize) + 1;
  }
  if tree[id].right != -1 {
    h2 = set_height(tree, tree[id].right as usize) + 1;
  }

  tree[id].height = max(h1, h2);
  tree[id].height
}

fn print_tree(tree: &[Node]) {
  for node in tree {
    let mut node_type = "leaf".to_string();

    if node.parent == -1 {
      node_type = "root".to_string();
    } else if node.left != -1 || node.right != -1 {
      node_type = "internal node".to_string();
    }

    println!(
      "node {}: parent = {}, sibling = {}, degree = {}, depth = {}, height = {}, {}",
      node.id,
      node.parent,
      node.sibling,
      node.degree,
      node.depth,
      node.height,
      node_type);
  }
}
