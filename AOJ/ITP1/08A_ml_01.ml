(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_8_A/review/5472874/que0/OCaml *)
String.map
  (fun c -> let i = int_of_char c in char_of_int (i lxor (49/(abs(abs(i*2-187)-32)+24)*32)))
  (read_line ())
|> print_endline
