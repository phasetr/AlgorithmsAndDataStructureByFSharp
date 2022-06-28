(* https://atcoder.jp/contests/abc156/submissions/10273233 *)
let n = read_int () in
let x = Array.init n (fun _ -> Scanf.scanf " %d" (fun x -> x)) in
let rec loop i minx =
  if i = 101 then minx else
    let sum = Array.fold_left (fun acc x -> acc + (x - i) * (x - i)) 0 x in
    loop (i + 1) (min sum minx)
in loop 0 99999999 |> Printf.printf "%d\n"
