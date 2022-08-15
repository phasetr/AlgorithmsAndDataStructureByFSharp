// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_3_C/review/3824119/shiitakealien/Rust
fn main() {
  let stdin = std::io::stdin();
  let mut buf = String::new();
  stdin.read_line(&mut buf).ok();
  let n: usize = buf.trim().parse().unwrap_or(0);

  let mut dll = Vec::new();
  let mut head = 0;

  for _ in 0..n {
    //println!("{:?}",dll);
    let mut buf = String::new();
    stdin.read_line(&mut buf).ok();
    let vec: Vec<&str> = buf.split_whitespace().collect();

    if vec[0] == "insert" {
      dll.push(vec[1].parse().unwrap_or(0));
    } else if vec[0] == "delete" {
      for j in (head..dll.len()).rev() {
        if vec[1].parse().unwrap_or(0) == dll[j] {
          dll.remove(j);
          break;
        }
      }
    } else if vec[0] == "deleteFirst" {
      dll.pop();
    } else if vec[0] == "deleteLast" {
      head += 1;
    }
  }
  for i in (head..dll.len()).rev() {
    print!("{}", dll[i]);
    if i == head {
      break;
    }
    print!(" ");
  }
  println!();
}
