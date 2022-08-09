(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_2_B/review/2412528/rabbisland/OCaml *)
open Str

let read_list f = split (regexp " +") (read_line ()) |> List.map f
let print_array a = Array.to_list a |> List.map string_of_int |> String.concat " " |> print_endline

let selection_sort a n =
  let rec iter i j minj c =
    if i = n then c
    else if j = n then begin
        if i = minj then iter (i+1) (i+1) (i+1) c
        else begin
            let t = a.(i) in
            a.(i) <- a.(minj);
            a.(minj) <- t;
            iter (i+1) (i+1) (i+1) (c+1)
          end
      end
    else
      if a.(j) < a.(minj) then iter i (j+1) j c
      else iter i (j+1) minj c
  in iter 0 0 0 0

let () =
  let n = read_int () in
  let ar = Array.of_list (read_list int_of_string) in
  let c = selection_sort ar n in
  print_array ar ; print_endline (string_of_int c)
