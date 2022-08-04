(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_1_A/review/1865936/superluminalsloth/OCaml *)
let print_array l = Array.fold_left (fun x y -> (if x = "" then "" else x^" ")^(string_of_int y)) "" l |> print_endline;;
let to_list s = Str.split (Str.regexp_string " ") s |> List.map (fun x -> int_of_string x) |> Array.of_list;;

let rec sort l = function
  | i when i = Array.length l -> print_array l;l
  | i ->
     print_array l;
     let key = l.(i) in
     let rec insert l2 = function
       | j when j < 0 || l2.(j) <= key -> l2.(j+1)<-key;l2
       | j -> l2.(j+1)<-l2.(j); insert l2 (j-1)
     in sort (insert l (i-1)) (i+1);;

let _ = read_int () and a = read_line () |> to_list;;
let _ = sort a 1;;
