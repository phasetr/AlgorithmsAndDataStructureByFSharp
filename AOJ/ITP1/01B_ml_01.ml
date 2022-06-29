(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_1_B/review/2289780/suibaka/OCaml *)
let _ =
  let x = read_line () in
  let x = int_of_string x in
  let x = x * x * x in
  print_endline (string_of_int x)
