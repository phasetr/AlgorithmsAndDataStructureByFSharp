(* https://atcoder.jp/contests/abc076/submissions/3592798 *)
let s' = read_line () in
let t = read_line () in
let regexp =
  Array.init (String.length t) (fun i->Printf.sprintf "[%c\\?]" t.[i])
  |> Array.to_list
  |> String.concat ""
  |> Str.regexp
in
try
  let i = Str.search_backward regexp s' (String.length s') in
  let s' = Str.string_before s' i^t^Str.string_after s' (i+String.length t) in
  let s' = String.map(function '?' -> 'a' | c->c) s' in
  Printf.printf "%s\n" s'
with _ -> print_endline "UNRESTORABLE"
