(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_1_D/review/2406280/rabbisland/OCaml *)
let () =
  let n = read_int () in
  let r1 = read_int () in
  let r2 = read_int () in
  let rec iter mp mr m =
    if m = 0 then mp
    else let r = read_int () in
         iter (max mp (r - mr)) (min mr r) (m-1) in
  iter (r2 - r1) (min r1 r2) (n-2) |> string_of_int |> print_endline
