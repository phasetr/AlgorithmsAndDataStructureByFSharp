(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_10_A/review/1870547/superluminalsloth/OCaml *)
let fib n =
  let rec fib a b = function
    | 0 -> a
    | n -> fib (a+b) a (n-1)
  in fib 1 0 n;;

let () =
  let n = read_int ()
  in fib n |> print_int;print_newline ();;
