(* https://atcoder.jp/contests/abc076/submissions/7853108 *)
let s' = read_line ()
let t = read_line ()
let n, m = String.(length s', length t)
let _ = String.(for i = n - m downto 0 do let b = ref true in iteri (fun j c -> if s'.[i + j] <> '?' && s'.[i + j] <> c then b := false) t;
  if !b then (print_endline @@ map (function '?' -> 'a' | c -> c) @@ sub s' 0 i ^ t ^ sub s' (i + m) (n - i - m); exit 0) done); print_endline "UNRESTORABLE"
