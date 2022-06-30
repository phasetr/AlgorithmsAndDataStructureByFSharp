(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_2_C/review/2960627/napo/OCaml *)
let () =
  let xs = Scanf.sscanf(read_line()) "%d %d %d" (fun x y z -> [|x;y;z|]) in
  Array.sort compare xs;
  Printf.printf "%d %d %d\n" xs.(0) xs.(1) xs.(2)
