(* https://atcoder.jp/contests/abc127/submissions/16457671 *)
let n, m = Scanf.scanf "%d %d" (fun n m -> n, m)

let d = Array.init (n + m) (fun i ->
  if i < n then Scanf.scanf " %d" (fun i -> 1, i)
  else Scanf.scanf " %d %d" (fun b c -> b, c))

let rec f i j ans =
  if i = n + m || j = 0 then ans
  else
    let b, c = d.(i) in
    let b = min b j in
    f (i + 1) (j - b) (ans + b * c)

let () =
  Array.sort (fun (_, c1) (_, c2) -> c2 - c1) d;
  Printf.printf "%d\n"  (f 0 n 0)
