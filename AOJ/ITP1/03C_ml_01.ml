(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_3_C/review/2781928/tetrose/OCaml *)
let rec f ()=
  let (x,y) = Scanf.sscanf(read_line()) "%d %d" (fun x y -> if x < y then (x,y) else (y,x))
  in
  if x <> 0 || y <> 0 then (Printf.printf "%d %d\n" x y;f()) else ();;
f ();;
