(* https://atcoder.jp/contests/abc076/submissions/3592893 *)
Scanf.scanf "%s %s" @@ fun s' t->
let reg = Str.global_replace (Str.regexp ".") "[\\0\\?]" t in
print_endline @@ try
  let i = Str.search_backward (Str.regexp reg) s' (String.length s') in
  Str.string_before s' i ^ t ^ Str.string_after s' (i+String.length t)
  |> String.map (function | '?' -> 'a' | c -> c)
with _ -> "UNRESTORABLE"
