(* https://atcoder.jp/contests/abc148/submissions/9088873 *)
let rec calc d x = if x < d then 0 else x / d + calc d (x / d)
let solve n =
  if n mod 2 = 1 then 0
  else min (calc 2 n) (calc 5 (n/2))
let _ = Scanf.scanf "%d" solve |> Printf.printf "%d\n"
