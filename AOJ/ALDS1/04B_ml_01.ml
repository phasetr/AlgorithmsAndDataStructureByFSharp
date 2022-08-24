(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_4_B/review/2422855/rabbisland/OCaml *)
open Str

let binary_search ar n x =
  let rec search l r =
    if l >= r then false else
      let m = (l + r) / 2 in
      if ar.(m) = x then true
      else if ar.(m) < x then search (m+1) r
      else search l m
  in search 0 n

let read_array f =
  split (regexp " +") (read_line ()) |> List.map f |> Array.of_list

let read_list f =
  split (regexp " +") (read_line ()) |> List.map f

let () =
  let n = read_int () in
  let s = read_array int_of_string in
  let _ = read_line () in
  let t = read_list int_of_string in
  List.fold_left (fun c x -> if binary_search s n x then c+1 else c) 0 t |> string_of_int |> print_endline
