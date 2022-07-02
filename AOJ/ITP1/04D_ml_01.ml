(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_4_D/review/1497875/kayabuyama8x/OCaml *)
let search (mini, maxi, total) n =
  ((min mini n), (max maxi n), (total + n))

let () =
  let () = ignore (read_line ())
  and data = read_line () in
  let mini, maxi, total = Str.split (Str.regexp " ") data |>
                            List.map int_of_string |>
                            List.fold_left search (max_int, min_int, 0) in
  Printf.printf "%d %d %d\n" mini maxi total
