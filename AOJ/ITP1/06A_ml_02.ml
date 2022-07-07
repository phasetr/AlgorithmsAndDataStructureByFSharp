(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_6_A/review/1503472/kayabuyama8x/OCaml *)
let () =
  ignore(read_line ());
  print_endline (read_line () |>
                   Str.split (Str.regexp " ") |>
                   List.rev |>
                   String.concat " ")
