(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_2_C/review/1494637/kayabuyama8x/OCaml *)
let () =
  let s = read_line () in
  let result = Str.split (Str.regexp " ") s |>
                 List.map int_of_string |>
                 List.sort (-) |>
                 List.map string_of_int |>
                 String.concat " " in
  print_endline result
