(* https://atcoder.jp/contests/abc148/submissions/9691302 *)
let n = read_int ()
let rec f n s p = if n / p = 0 then s else f n (s + n / p) (p * 5)
let _ = Printf.printf "%d\n" @@ if n mod 2 = 1 then 0 else f (n / 2) 0 5
