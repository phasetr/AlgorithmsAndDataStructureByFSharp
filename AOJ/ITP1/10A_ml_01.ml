(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_10_A/review/1839965/superluminalsloth/OCaml *)
let () =
  Scanf.scanf "%f %f %f %f\n" (fun x1 y1 x2 y2->sqrt( (x2-.x1)**2.0 +. (y2-.y1)**2.0 ) )
  |> print_float;print_newline();;
