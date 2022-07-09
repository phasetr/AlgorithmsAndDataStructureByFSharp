(* https://atcoder.jp/contests/abc044/submissions/7972522 *)
let w = read_line ()
let f s x = let n = ref 0 in String.iter (fun c -> if c = x then incr n) s; !n
let _ = String.iter (fun c -> if f w c mod 2 = 1 then (print_endline "No"; exit 0)) w; print_endline "Yes"
