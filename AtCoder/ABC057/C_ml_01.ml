(* https://atcoder.jp/contests/abc057/submissions/6327311 *)
let n = read_int ()
let i, d = ref 1, ref 1
let rec f n = if n <= 9 then 1 else 1 + f (n / 10)
let _ =
  while !i * !i < n do if n mod !i = 0 then d := !i; incr i done;
  Printf.printf "%d\n" @@ if !i * !i = n then f !i else f @@ n / !d
