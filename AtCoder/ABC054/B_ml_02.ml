(* https://atcoder.jp/contests/abc054/submissions/2140892 *)
open Scanf
let rec for_all_iter a b f = if a >= b then true else f a && for_all_iter (a+1) b f
let for_some_iter a b f = not @@ for_all_iter a b (fun a -> not (f a))
let () =
  let n, m = scanf "%d %d" (fun n m -> n, m) in
  let a = Array.init n (fun _ -> scanf " %s" (fun s -> s)) in
  let b = Array.init m (fun _ -> scanf " %s" (fun s -> s)) in
  let res = for_some_iter 0 (n-m+1) (fun i ->
    for_some_iter 0 (n-m+1) (fun j ->
      for_all_iter 0 m (fun k ->
        for_all_iter 0 m (fun l -> a.(i+k).[j+l] = b.(k).[l])))) in
  print_endline @@ if res then "Yes" else "No"
