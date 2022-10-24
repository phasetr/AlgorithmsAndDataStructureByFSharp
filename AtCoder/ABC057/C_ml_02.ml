(* https://atcoder.jp/contests/abc057/submissions/2254472 *)
let n = read_int ()
let rec f x = if n mod x = 0 then n / x else f (pred x)
let len_int x =
  let rec f tmp c = if tmp > 0 then f (tmp / 10) (succ c) else c in
  f x 0
let () = int_of_float (float n ** 0.5) |> f |> len_int |> Printf.printf "%d\n"
