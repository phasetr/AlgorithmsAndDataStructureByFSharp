(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_8_D/review/1841858/superluminalsloth/OCaml *)
let () =
  let l = read_line ()
  and w = read_line () |> Str.regexp in
  try let _ = Str.search_forward w (l^l) 0 in "Yes"
  with Not_found -> "No"; |> print_endline;;
