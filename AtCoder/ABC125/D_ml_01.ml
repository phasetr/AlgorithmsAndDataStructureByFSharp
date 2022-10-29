(* https://atcoder.jp/contests/abc125/submissions/6118889 *)
let n = Scanf.scanf " %d" @@ (+) 0
let a_s = Array.init n @@ fun _ -> Scanf.scanf " %d" @@ (+) 0
let c, m, s = Array.fold_left (fun (c, m, s) a -> (c + if a < 0 then 1 else 0), min m @@ abs a, s + abs a) (0, max_int, 0) a_s
let _ = Printf.printf "%d\n" @@ s - if c mod 2 = 1 then 2 * m else 0
