(* https://atcoder.jp/contests/abc139/submissions/15658199 *)
let solve a b = (b - 1 + a - 2) / (a - 1);;
let () = Scanf.scanf "%d %d" @@
           fun a b -> Printf.printf "%d\n" (solve a b)
