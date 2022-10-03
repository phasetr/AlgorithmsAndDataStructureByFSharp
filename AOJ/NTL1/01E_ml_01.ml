(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/NTL_1_E/review/2461659/r6eve/OCaml *)
let rec($)a b=if b=0then(1,0)else let(x,y)=b$(a mod b)in(y,x-a/b*y);;Scanf.scanf"%d %d"(fun a b->let(x,y)=a$b in Printf.printf"%d %d
"x y)
