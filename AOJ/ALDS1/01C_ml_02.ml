(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_1_C/review/1885325/superluminalsloth/OCaml *)
let is_prime n = match n with
    2|3|5|7 -> true
    | n when n mod 2 = 0 -> false
    | n ->
       let rec loop i =
         if i*i > n then true
         else if n mod i = 0 then false
         else loop (i+2);
       in loop 3

let () =
  let n = read_int () in
  let rec read ct = function
      0 -> ct
    | i ->
       let m = read_int () in
       read (if is_prime m then ct+1 else ct) (i-1) in
  Printf.printf "%d\n" (read 0 n)
