(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/NTL_1_B/review/6026786/ose20/OCaml *)
let rec modpow x n m =
  if n = 0 then 1
  else if n mod 2 = 0 then modpow (x*x mod m) (n/2) m
  else (mod) (x * modpow x (n-1) m) m

let () =
  Scanf.scanf "%d %d"
  @@ fun x n ->
     let m = 1_000_000_000 + 7 in
     Printf.printf "%d\n" (modpow x n m)
