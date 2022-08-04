(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_1_A/review/2404159/rabbisland/OCaml *)
open Str

let read_list f = split (regexp " +") (read_line ()) |> List.map f
let print_array a = Array.to_list a |> List.map string_of_int |> String.concat " " |> print_endline
let insertion_sort a n =
  let rec iloop i =
    if i = n then ()
    else
      let v = a.(i) in
      let rec jloop j =
        if j < 0 || a.(j) <= v then a.(j+1) <- v
        else
          begin
            a.(j+1) <- a.(j);
            jloop (j-1)
          end
      in jloop (i-1); print_array a; iloop (i+1)
  in print_array a; iloop 1

let () =
  let n = read_int () in
  let ar = Array.of_list (read_list int_of_string) in
  insertion_sort ar n
