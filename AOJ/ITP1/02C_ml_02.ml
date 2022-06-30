(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_2_C/review/2289825/suibaka/OCaml *)
let _ =
  let swap a b
    = if a > b then (b, a)
      else (a, b) in
  let a, b, c = Scanf.scanf "%d %d %d" (fun a b c -> a, b, c) in
  let a, b = swap a b in
  let b, c = swap b c in
  let a, b = swap a b in
  Printf.printf "%d %d %d\n" a b c
