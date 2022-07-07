(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_6_A/review/2963318/napo/OCaml *)
let rec print_list xss = match xss with
  | []  -> print_newline ()
  | [x] -> Printf.printf "%s\n" x
  | (x :: xs) -> Printf.printf "%s " x; print_list xs
;;

let () =
  let _ = read_line() in
  read_line()
  |> Str.split (Str.regexp_string " ")
  |> List.map int_of_string
  |> List.rev
  |> List.map string_of_int
  |> print_list
;;
