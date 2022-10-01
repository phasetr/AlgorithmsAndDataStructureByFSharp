(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/NTL_1_D/review/2461550/r6eve/OCaml *)
let prime_factors n =
  let rec doit i x acc =
    if i*i > n then
      if x = 1 then acc
      else x :: acc
    else if x mod i = 0 then doit i (x / i) (i :: acc)
    else doit (i + 1) x acc in
  doit 2 n []

let decon lst =
  List.fold_left (fun acc x -> match acc with
    | [] -> [x]
    | y :: _ -> if x = y then acc else x :: acc) [] lst

let phi_func n =
  prime_factors n
  |> decon
  |> List.fold_left (fun acc x -> acc *. (1. -. 1. /. (float x))) (float n)
  |> int_of_float

let () =
  let n = read_int () in
  phi_func n |> Printf.printf "%d\n"

