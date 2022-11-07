(* https://atcoder.jp/contests/abc138/submissions/7357213 *)
let n, q = Scanf.scanf " %d %d" @@ fun a b -> a, b
let g, ans = Array.(make n [], make n 0)
let rec f v p = List.iter (fun u -> if u <> p then (ans.(u) <- ans.(u) + ans.(v); f u v)) g.(v)
let _ = Scanf.(for _ = 1 to n - 1 do scanf " %d %d" @@ fun u v -> g.(u - 1) <- v - 1 :: g.(u - 1); g.(v - 1) <- u - 1 :: g.(v - 1) done;
  for _ = 1 to q do scanf " %d %d" @@ fun p x -> ans.(p - 1) <- ans.(p - 1) + x done);
  f 0 ~-1; Array.iteri (fun i n -> Printf.printf (if i = 0 then "%d" else " %d") n) ans; print_newline ()
