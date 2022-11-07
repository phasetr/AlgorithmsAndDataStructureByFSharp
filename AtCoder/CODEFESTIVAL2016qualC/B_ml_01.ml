(* https://atcoder.jp/contests/code-festival-2016-qualc/submissions/7944514 *)
let k, t = Scanf.scanf " %d %d" @@ fun a b -> a, b
let a_s = Array.init t @@ fun _ -> Scanf.scanf " %d" (+) 0
let _ = Printf.printf "%d\n" @@ max 0 @@ 2 * Array.fold_left max a_s.(0) a_s - k - 1
