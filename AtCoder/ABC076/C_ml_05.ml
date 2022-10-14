(* https://atcoder.jp/contests/abc076/submissions/1719070 *)
let array_of_string s = Array.init (String.length s) (fun i -> s.[i])

let () =
  let s' = read_line () in
  let t = read_line () in
  let regexp =
    array_of_string t
    |> Array.to_list
    |> List.map (Printf.sprintf "[%c\?]")
    |> String.concat ""
    |> Str.regexp in
  try
    let i = Str.search_backward regexp s' (String.length s') in
    Printf.printf "%s%s%s\n"
      (String.map (function '?' -> 'a' | c -> c) (String.sub s' 0 i))
      t
      (String.map (function '?' -> 'a' | c -> c) (String.sub s' (i + String.length t) (String.length s' - i - String.length t)))
  with Not_found -> print_endline "UNRESTORABLE"
