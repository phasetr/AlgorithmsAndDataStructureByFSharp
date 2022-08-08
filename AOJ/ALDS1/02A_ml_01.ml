(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_2_A/review/2038729/ydash/OCaml *)
let sort array n =
  let rec bubble_sort a c =
    let rec bubble c = function
      | 0 -> a,c
      | i ->
         let ai,aj = a.(i),a.(i-1) in
         bubble (if ai < aj then (a.(i) <- aj; a.(i-1) <- ai; c+1) else c) (i-1) in
    match bubble 0 n with
    | v,0 -> v,c
    | v,t -> bubble_sort v (c+t) in
  bubble_sort array 0

let () =
  let n = read_int () in
  let a = read_line () |> Str.split (Str.regexp " ")
          |> List.map int_of_string |> Array.of_list in
  let sorted,c = sort a (n-1) in
  Array.iteri
    (fun i x -> Printf.printf (if i=n-1 then "%d\n" else "%d ") x) sorted;
  Printf.printf "%d\n" c
