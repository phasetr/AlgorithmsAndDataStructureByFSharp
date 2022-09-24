(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_14_A/review/2470183/rabbisland/OCaml *)
let () =
  let t = read_line () in
  let p = read_line () in
  let pl = String.length p in
  let rec loop i =
    if String.sub t i pl = p then
      string_of_int i |> print_endline;
    loop (i+1) in
  try loop 0 with _ -> ()
