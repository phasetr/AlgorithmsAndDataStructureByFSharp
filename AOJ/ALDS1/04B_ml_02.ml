(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_4_B/review/1922902/superluminalsloth/OCaml *)
let to_array s =
  Str.split (Str.regexp_string " ") s
  |> List.map int_of_string
  |> Array.of_list

let binary_search l value =
  let rec loop left right =
    let mid = (left+right)/2 in
    if left > right then 0
    else if l.(mid) = value then 1
    else
      let (l_new, r_new) =
        if value < l.(mid) then (left, mid-1)
        else (mid+1, right)
      in
      loop l_new r_new
  in loop 0 ((Array.length l)-1);;

let _ = read_int () and
    s = read_line () |> to_array and
    _ = read_int () and
    t = read_line () |> to_array in
    let count = Array.fold_left (fun x y -> x + (binary_search s y)) 0 t in
    Printf.printf "%d\n" count
