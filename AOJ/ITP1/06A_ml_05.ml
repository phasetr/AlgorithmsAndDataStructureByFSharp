(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_6_A/review/5464436/que0/OCaml *)
let _ = read_line () in
  let ls = Str.split (Str.regexp " ") (read_line ()) in
  print_string @@ String.concat " " @@ List.rev ls;
  print_newline()
