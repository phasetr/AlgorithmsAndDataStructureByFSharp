// https://onlinejudge.u-aizu.ac.jp/solutions/problem/DSL_1_A/review/3118068/tempura0224/Rust
struct UnionFind{
  par:Vec<usize>,
}

impl UnionFind{
  fn new(n:usize)->UnionFind{
    let mut v=Vec::<usize>::new();
    for i in 0..n{
      v.push(i);
    }
    UnionFind{par:v,}
  }

  fn find(&mut self,x:usize)->usize{
    if self.par[x]!=x{
      let z=self.par[x];
      self.par[x]=self.find(z);
      self.par[x]
    }
    else {
      x
    }
  }
  fn unite(&mut self,x:usize,y:usize){
    let xx=self.find(x);
    let yy=self.find(y);
    self.par[yy]=xx;
  }

  fn same(&mut self,x:usize,y:usize)->i32{
    if self.find(x)==self.find(y){
      return 1;
    }
    0
  }
}

fn main(){
  let mut s = String::new();
  std::io::stdin().read_line(&mut s).unwrap();
  let v:Vec<usize>=s.trim().split_whitespace()
    .map(|e|e.parse().unwrap()).collect();
  let (n,m)=(v[0],v[1]);
  let mut uf =UnionFind::new(n);
  for _ in 0..m {
    let mut t = String::new();
    std::io::stdin().read_line(&mut t).unwrap();
    let x:Vec<usize>=t.trim().split_whitespace()
      .map(|e|e.parse().unwrap()).collect();
    match x[0]{
      1 => println!("{}",uf.same(x[1], x[2]) ),
      0 => uf.unite(x[1],x[2]),
      _ => println!("{}",x[0]),
    }
  }
}
