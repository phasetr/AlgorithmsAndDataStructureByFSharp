(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_3_A/review/2060551/r6eve/OCaml *)
let () =
  let l = Str.split (Str.regexp " ") (read_line ()) in
  let doit = function
    | (x::y::acc, "+") -> (y + x) :: acc
    | (x::y::acc, "-") -> (y - x) :: acc
    | (x::y::acc, "*") -> (y * x) :: acc
    | (acc, n) -> (int_of_string n) :: acc in
  Printf.printf "%d\n" (List.hd (List.fold_left (fun acc x -> doit (acc, x)) [] l))
