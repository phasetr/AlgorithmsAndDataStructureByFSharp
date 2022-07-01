(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_3_D/review/2289876/suibaka/OCaml *)
let rec range x y = if x > y then [] else (x :: range (x+1) y)
let solve a b c =
  let ok n = c mod n == 0 in
  range a b |> List.filter ok |> List.length |> Printf.printf "%d\n"
let _ = Scanf.scanf "%d %d %d" solve
