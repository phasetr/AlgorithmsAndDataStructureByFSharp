(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_9_A/review/1879824/superluminalsloth/OCaml *)
let split = Str.split (Str.regexp_string " ");;

let () =
  let word = read_line () in
  let rec read ct =
    let sentence = read_line () in
    let s = sentence |> split in
    let count = List.fold_left (fun x y -> if String.uppercase_ascii y = String.uppercase_ascii word then x+1 else x) 0 s in
    if String.trim sentence = "END_OF_TEXT"  then (ct+count)
    else read (ct+count)
  in
  Printf.printf "%d\n" (read 0);;
