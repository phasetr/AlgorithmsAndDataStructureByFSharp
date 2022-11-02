(* https://atcoder.jp/contests/abc110/submissions/7213914 *)
let s = read_line ()
let t = read_line ()
let fs, ts = Array.(make 26 ~-1, make 26 ~-1)
let g c = Char.(code c - code 'a')
let f i c = let a, b = g c, g t.[i] in
  if fs.(a) <> -1 || ts.(b) <> -1 then if fs.(a) <> b || ts.(b) <> a then (print_endline "No"; exit 0); fs.(a) <- b; ts.(b) <- a
let _ = String.iteri f s; print_endline "Yes"
