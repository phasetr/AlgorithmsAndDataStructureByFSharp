(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_2_C/review/1995674/r6eve/OCaml *)
Scanf.scanf "%d %d %d"
  (fun a b c ->
    match List.sort (-) [a;b;c] with [x;y;z] -> Printf.printf "%d %d %d\n" x y z |_ -> ());;
