(* https://atcoder.jp/contests/abc148/submissions/12557519 *)
let id x = x
let n = Scanf.scanf "%d\n" id
let rec f = function
  | i when i * 2 > n -> []
  | i -> (n / i / 2) :: f (i * 5)
let () = print_int @@ if n mod 2 = 1 then 0 else List.fold_left (+) 0 (f 5)
