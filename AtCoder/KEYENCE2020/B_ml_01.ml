(* https://atcoder.jp/contests/keyence2020/submissions/10085994 *)
open Printf
open Scanf

let solve n =
  let ar = Array.init n @@ fun _ -> scanf "%d %d " @@ fun x l -> (x+l, x-l) in
  Array.fast_sort compare ar;
  fst @@ Array.fold_left (fun (ct, p) (r, l) -> if p <= l then (ct + 1, r) else (ct, p)) (0, -1000000000) ar

let () =
  scanf "%d " solve |> printf "%d\n"
