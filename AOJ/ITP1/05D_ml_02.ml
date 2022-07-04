(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_5_D/review/2963157/napo/OCaml *)
let () =
  let n = read_int() in
  for i = 3 to n do
    if i mod 3 = 0 || String.contains (string_of_int i) '3' then
      Printf.printf " %d" i;
  done;
  print_newline();;
