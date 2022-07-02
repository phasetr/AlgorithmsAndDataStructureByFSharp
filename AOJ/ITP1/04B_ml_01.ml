(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_4_B/review/2289890/suibaka/OCaml *)
let _ =
  let r = Scanf.scanf "%f" (fun r -> r) in
  let pi = acos (-1.0) in
  Printf.printf "%f %f\n" (r *. r *. pi) (2.0 *. r *. pi)
