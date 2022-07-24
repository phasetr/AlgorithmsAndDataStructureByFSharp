(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_9_A/review/2031892/ydash/OCaml *)
let () =
  let w = read_line () in
  let rec loop count =
    match read_line () with
    | "END_OF_TEXT" -> Printf.printf "%d\n" count
    | s -> loop (Str.split (Str.regexp " ") s
                 |> List.fold_left
                      (fun acc x ->if String.lowercase_ascii x = String.lowercase_ascii w then acc+1 else acc)
                      0
                 |> (+) count)
  in loop 0
