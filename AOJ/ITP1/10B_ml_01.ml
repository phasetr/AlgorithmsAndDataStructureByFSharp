(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_10_B/review/4032857/Wasedadaigaku/OCaml *)
let () =
  let a,b,c = Scanf.scanf "%f %f %f\n" (fun a b c -> a, b, c *. (atan 1.) /. 45.) in
  let h = b *. (sin c) in
  let s = a *. h *. 0.5 in
  let l = a +. b +. sqrt ( a ** 2. +. b ** 2. -. 2. *. a *. b *. (cos c)) in
  Printf.printf "%f\n%f\n%f\n" s l h;;
