(* https://atcoder.jp/contests/abc084/submissions/8235579 *)
let n = Scanf.scanf " %d" (+) 0
let cs, ss, fs = Array.(make (n - 1) 0, make (n - 1) 0, make (n - 1) 0)
let _ = for i = 0 to n - 2 do Scanf.scanf " %d %d %d" @@ fun a b c -> cs.(i) <- a; ss.(i) <- b; fs.(i) <- c done;
  for j = 0 to n - 1 do let t = ref 0 in for i = j to n - 2 do t := ss.(i) + max 0 ((!t - ss.(i) + fs.(i) - 1) / fs.(i)) * fs.(i) + cs.(i) done; Printf.printf "%d\n" !t done
