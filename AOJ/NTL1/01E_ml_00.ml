(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/NTL_1_E/review/2461659/r6eve/OCaml *)
let solve a b =
  let rec ($) a b =
    if b=0 then (1,0) else let(x,y) = b $ (a mod b) in (y,x-a/b*y) in
  a $ b

let () =
  let x,y = Scanf.scanf "%d %d" (fun a b -> solve a b) in
  Printf.printf "%d %d\n" x y;;

Printf.printf "%B\n" (solve 4 12 == (1,0));;
Printf.printf "%B\n" (solve 3 8  == (3,-1));;
