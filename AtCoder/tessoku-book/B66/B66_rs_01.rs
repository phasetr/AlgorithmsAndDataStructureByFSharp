// https://atcoder.jp/contests/tessoku-book/submissions/37962600
#![allow(dead_code,unused_imports,unused_variables,non_snake_case, non_upper_case_globals, path_statements)]
use itertools::Itertools;
use petgraph::unionfind::UnionFind;
use proconio::{fastout, input,marker::{Chars, Bytes, Isize1, Usize1}};
use std::{
    cmp::{max, min, Reverse},
    collections::{BTreeMap, BTreeSet, BinaryHeap, HashMap, HashSet, VecDeque},
    process::exit,
};

#[fastout]
fn main() {
    input! {
        N: usize,
        M: usize,
        edges: [(Usize1, Usize1); M],
        Q:usize,
    }

    let mut query = vec![];
    let mut set = HashSet::<usize>::new();
    for i in 0..N{
        set.insert(i);
    }
    for _ in 0..Q{
        input! {t:usize}
        if t == 1{
            input! {x:Usize1}
            query.push((1,x,0));
            set.remove(&x);
        }else{
            input! {
                u:Usize1,
                v:Usize1
            }
            query.push((2,u,v));
        }
    }

    let mut uf = UnionFind::<usize>::new(N);
    for i in 0..M{
        if set.contains(&i){
            uf.union(edges[i].0, edges[i].1);
        }
    }
    let mut ans = vec![];
    for i in (0..Q).rev() {
        let t = query[i].0;
        if t == 1{
            let x = query[i].1;
            uf.union(edges[x].0, edges[x].1);
        }else{
            let (u,v) = (query[i].1, query[i].2);
            if uf.equiv(u, v) {
                ans.push("Yes");
            }else{
                ans.push("No");
            }
        }
    }

    ans.reverse();
    for a in ans{
        println!("{}",a);
    }
}
