(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_4_A/review/2422604/rabbisland/OCaml *)
open Printf
open Str

let read_list f = split (regexp " +") (read_line ()) |> List.map f

let () =
  let _ = read_line () in
  let s = read_list int_of_string in
  let _ = read_line () in
  let t = read_list int_of_string in
  List.fold_left (fun c x -> if List.mem x s then c+1 else c) 0 t |> string_of_int |> print_endline
