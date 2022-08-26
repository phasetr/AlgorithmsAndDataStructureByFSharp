(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_5_A/review/2425897/rabbisland/OCaml *)
open Str

let read_list f = split (regexp " +") (read_line ()) |> List.map f

let () =
  let _ = read_line () in
  let al = read_list int_of_string in
  let _ = read_line () in
  let ml = read_list int_of_string in
  let makeable m =
    let rec iter s = function
      | [] -> if s = m then true else false
      | x :: xs -> if s > m then false
                   else if s = m then true
                   else (iter s xs || iter (s+x) xs) in
    iter 0 al in
  List.iter (fun x -> print_endline (if makeable x then "yes" else "no")) ml
