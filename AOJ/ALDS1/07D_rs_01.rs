// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_7_D/review/4991057/sandbox0436/Rust
use std::io::Read;

fn main(){
  let mut buf = String::new();
  std::io::stdin().read_to_string(&mut buf).unwrap();
  let mut iter = buf.split_whitespace()
    .map(|x| x.parse::<usize>().unwrap());
  let n = iter.next().unwrap();
  let pre_array: Vec<usize> = iter.clone().take(n).collect();
  let in_array: Vec<usize> = iter.skip(n).collect();

  let mut ans = String::new();
  solve(&mut ans,&pre_array, &in_array);
  println!("{}", ans.trim());
}

fn solve(ans: &mut String, pre_ary: &[usize] , in_ary: &[usize]){
  let a = pre_ary.split_first();
  match a {
    None => return,
    Some((x, p_ary)) => {
      let sep = in_ary.iter().take_while(|&i| i !=x).count();
      let (il, ir) = (&in_ary[0..sep], &in_ary[(sep + 1)..]);
      let (pl, pr) = p_ary.split_at(il.len());

      solve(ans, pl, il);
      solve(ans, pr, ir);

      *ans += &format!("{} ", x.to_string());
    },
  }
}
