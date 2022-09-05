// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_7_C/review/5192566/boiler21/Rust
struct Node {
  parent: Option<usize>,
  left: Option<usize>,
  right: Option<usize>,
}

impl Node {
  fn new() -> Node {
    Node { parent: None, left: None, right: None }
  }
}

fn preorder(a: &Vec<Node>, id: Option<usize>) {
  if let Some(id) = id {
    print!(" {}", id);
    preorder(a, a[id].left);
    preorder(a, a[id].right);
  }
}

fn inorder(a: &Vec<Node>, id: Option<usize>) {
  if let Some(id) = id {
    inorder(a, a[id].left);
    print!(" {}", id);
    inorder(a, a[id].right);
  }
}

fn postorder(a: &Vec<Node>, id: Option<usize>) {
  if let Some(id) = id {
    postorder(a, a[id].left);
    postorder(a, a[id].right);
    print!(" {}", id);
  }
}

fn main() {
  let mut s = String::new();
  std::io::stdin().read_line(&mut s).ok();
  let n: usize = s.trim().parse().unwrap();

  let mut a: Vec<Node> = Vec::new();

  for _ in 0..n {
    a.push(Node::new());
  }

  for _ in 0..n {
    s.clear();
    std::io::stdin().read_line(&mut s).ok();
    let b: Vec<i64> = s.split_whitespace().map(|x| x.parse().unwrap()).collect();
    let id = if b[0] < 0 { None } else { Some(b[0] as usize) };
    let left = if b[1] < 0 { None } else { Some(b[1] as usize) };
    let right = if b[2] < 0 { None } else { Some(b[2] as usize) };
    if let Some(id) = id {
      a[id].left = left;
      a[id].right = right;
    }
    if let Some(left) = left {
      a[left].parent = id;
    }
    if let Some(right) = right {
      a[right].parent = id;
    }
  }

  let root = a.iter().position(|x| x.parent == None);

  println!("Preorder");
  preorder(&a, root);
  println!();

  println!("Inorder");
  inorder(&a, root);
  println!();

  println!("Postorder");
  postorder(&a, root);
  println!();
}
