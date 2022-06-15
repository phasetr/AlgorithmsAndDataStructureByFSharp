(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_10_A/review/2447621/rabbisland/OCaml *)
open Printf
open Scanf

let id x = x

let fib n =
  let dp = Array.make (n+1) 1 in
  let rec iter i =
    if i > n then dp.(n)
    else begin
        dp.(i) <- dp.(i-2) + dp.(i-1);
        iter (i+1)
      end
  in iter 2

let () =
  let n = scanf "%d\n" id in
  fib n |> printf "%d\n"
