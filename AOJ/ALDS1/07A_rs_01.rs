// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_7_A/review/4266213/kann0/Rust
use std::io::Read;

fn main() {
  let mut buf = String::new();
  std::io::stdin().read_to_string(&mut buf).unwrap();

  let answer = solve(&buf);

  println!("{}", answer);
}

fn solve(input: &str) -> String {
  let mut iterator = input.split_whitespace();

  let n: usize = iterator.next().unwrap().parse().unwrap();

  let mut t: Vec<Node> = vec![Node { parent: -1, left: -1, right: -1, depth: -1 }; n];

  let mut l: usize = 0;
  for _ in 0..n {
    let v: usize = iterator.next().unwrap().parse().unwrap();
    let d: usize = iterator.next().unwrap().parse().unwrap();
    for j in 0..d {
      let c: isize = iterator.next().unwrap().parse().unwrap();
      if j == 0 {
        t[v].left = c;
      } else {
        t[l].right = c;
      }
      l = c as usize;
      t[c as usize].parent = v as isize;
    }
  }

  let root = t.iter().position(|it| it.parent == -1).unwrap();

  rec(root, 0, &mut t);

  let mut ans = String::new();
  for i in 0..n {
    let node = &t[i];
    ans += &format!("node {}: parent = {}, depth = {}, ", i, node.parent, node.depth);
    if node.parent == -1 {
      ans += &format!("root, ");
    } else if node.left == -1 {
      ans += &format!("leaf, ");
    } else {
      ans += &format!("internal node, ");
    }

    ans += "[";
    let mut count = 0;
    let mut child = node.left;
    while child != -1 {
      if count > 0 {
        ans += ", ";
      }
      ans += &format!("{}", child);
      child = t[child as usize].right;
      count += 1;
    }
    ans += "]\n";
  }

  return ans.trim().to_string();
}

fn rec(id: usize, depth: isize, tree: &mut Vec<Node>) {
  tree[id].depth = depth;
  if tree[id].right != -1 {
    rec(tree[id].right as usize, depth, tree);
  }
  if tree[id].left != -1 {
    rec(tree[id].left as usize, depth + 1, tree);
  }
}

#[derive(Clone)]
struct Node {
  parent: isize,
  left: isize,
  right: isize,
  depth: isize,
}
