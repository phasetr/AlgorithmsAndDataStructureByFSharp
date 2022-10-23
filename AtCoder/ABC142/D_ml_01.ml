(* https://atcoder.jp/contests/abc142/submissions/9367200 *)
let f n =
  let rec f a c d m =
    if d > m || d * d > n then
      if c > 0 then (d, c) :: a
      else if m > 1 then (m, 1) :: a else a else if m mod d = 0 then f a (c + 1) d @@ m / d else f (if c > 0 then (d, c) :: a else a) 0 (d + 1) m in f [] 0 2 n
let rec g a b = if b = 0 then a else g b (a mod b)
let _ = Scanf.scanf "%d %d" @@ fun a b -> 1 + (List.length @@ f @@ g a b) |> Printf.printf "%d\n"
