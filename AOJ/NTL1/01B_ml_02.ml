(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/NTL_1_B/review/2456668/r6eve/OCaml *)
let z = 1000000007

let rec pow (x, n) =
  if n = 0 then 1
  else if n mod 2 = 0 then pow (x * x mod z, n / 2)
  else pow (x * x mod z, n / 2) * x mod z

let () =
  Scanf.scanf "%d %d\n" (fun m n -> (m, n))
  |> pow |> Printf.printf "%d\n"
