(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_10_A/review/2030064/ydash/OCaml *)
let () =
  let x,y = Scanf.scanf "%f %f %f %f\n" (fun a b c d -> a-.c,b-.d) in
  Printf.printf "%f\n" (hypot x y)
