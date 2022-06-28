(* https://atcoder.jp/contests/abc139/submissions/7446056 *)
let solve a b = ((b-1)+a-2) / (a-1);;
let a,b = Scanf.scanf " %d %d" (fun a b -> a, b);;
let () = Printf.printf "%d\n" (solve a b)
