(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_4_D/review/2425705/rabbisland/OCaml *)
open Printf
open Scanf

let rec read f n =
  if n <= 0 then []
  else let x = f () in x :: read f (n - 1)

let () =
  let n, k = sscanf (read_line ())"%d %d" (fun x y -> (x, y)) in
  let ws = read read_int n in
  let rec allocatable c w xs p =
    if c + 1 > k then false
    else match xs with
         | [] -> true
         | y :: ys -> let w' = w + y in
                      if w' > p then allocatable (c+1) 0 xs p
                      else allocatable c w' ys p in
  let rec loop fp tp =
    if tp - fp = 1 then tp
    else let p' = (fp + tp) / 2 in
         if allocatable 0 0 ws p' then loop fp p'
         else loop p' tp in
  loop 0 1000000000 |> string_of_int |> print_endline
