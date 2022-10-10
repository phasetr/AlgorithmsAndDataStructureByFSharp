(* https://atcoder.jp/contests/abc048/submissions/6317559 *)
let a, b, x = Scanf.scanf " %d %d %d" @@ fun a b c -> a, b, c
let f n = if n < 0 then 0 else n / x + 1
let _ = Printf.printf "%d\n" @@ f b - f (a - 1)
