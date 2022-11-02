(* https://atcoder.jp/contests/abc049/submissions/6048694 *)
(* O(|s|) *)
open Str
let s = read_line ()
let _ = print_endline @@ if string_match (regexp "^\\(dream\\|dreamer\\|erase\\|eraser\\)+$") s 0 then "YES" else "NO"
