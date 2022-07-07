(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_6_B/review/1995992/r6eve/OCaml *)
let n=read_int();;
let rec($)i a =
  if i>n
  then Bytes.iter
         (fun c->for i=1 to 13 do
                   if not(List.mem(c,i)a)then Printf.printf "%c %d" c i;done) "SHCD"
  else(i+1)$(Scanf.scanf"%c %d\n" (fun c n -> c,n )::a);;
1$[]
