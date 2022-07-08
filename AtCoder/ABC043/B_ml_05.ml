(* https://atcoder.jp/contests/abc043/submissions/918045 *)
let step out key =
  match key with
  | "B" ->
     begin match out with
     | [] -> []
     | _ :: xs -> xs
     end
  | _ ->
     key :: out

let () =
  read_line ()
  |> Str.split (Str.regexp "")
  |> List.fold_left step []
  |> List.rev
  |> String.concat ""
  |> print_endline
