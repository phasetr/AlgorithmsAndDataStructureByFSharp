(* https://atcoder.jp/contests/abc049/submissions/2905500 *)
let rec solve = function
  | 'm' :: 'a' :: 'e' :: 'r' :: 'd' :: s
  | 'e' :: 's' :: 'a' :: 'r' :: 'e' :: s
  | 'r' :: 'e' :: 's' :: 'a' :: 'r' :: 'e' :: s
  | 'r' :: 'e' :: 'm' :: 'a' :: 'e' :: 'r' :: 'd' :: s -> solve s
  | [] -> true
  | _ -> false

let () =
  let s = read_line () in
  Array.init (String.length s) (fun i -> s.[i])
  |> Array.to_list
  |> List.rev
  |> solve
  |> (function true -> "YES" | false -> "NO")
  |> print_endline
