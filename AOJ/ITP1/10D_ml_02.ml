(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_10_D/review/4033054/Wasedadaigaku/OCaml *)
let () =
  let n = read_int () in
  let rec read_vec acc = function
      0 -> acc
    | i -> let f = Scanf.scanf " %f" (fun f -> f ) in
           read_vec (f::acc) (i-1)
  in
  let x = read_vec [] n in
  let y = read_vec [] n in
  let x_y = List.map2 (fun x y -> abs_float (x -. y)) x y in
  let d p = List.fold_left (fun a b -> a +. b ** p ) 0. x_y ** (1. /. p) in
  let d_inf = List.fold_left max 0. x_y in
  Printf.printf "%f\n%f\n%f\n%f\n" (d 1.) (d 2.) (d 3.) d_inf;;
