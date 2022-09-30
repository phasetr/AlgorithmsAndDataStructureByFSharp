(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/NTL_1_C/review/2461508/r6eve/OCaml *)
let gcd m n =
  let rec doit x y =
    if y <= 0 then x else doit y (x mod y) in
  doit (max m n) (min m n)

let lcm m n = m * n / (gcd m n)

let () =
  let _ = read_int () in
  match read_line () |> Str.split (Str.regexp " ") |> List.map int_of_string with
  | x :: xs -> List.fold_left lcm x xs |> Printf.printf "%d\n"
  | _ -> assert false
