(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_1_C/review/2406187/rabbisland/OCaml *)
let is_prime = function
    1 -> false
  | 2 -> true
  | n when n mod 2 = 0 -> false
  | n -> let rec iter x =
           if x * x > n then true
           else if n mod x = 0 then false
           else iter (x+2) in
         iter 3

let rec read f n =
  if n <= 0 then []
  else let x = f () in x :: read f (n - 1)

let () =
  let n = read_int () in
  let xs = read read_int n in
  List.filter is_prime xs |> List.length |> string_of_int |> print_endline
