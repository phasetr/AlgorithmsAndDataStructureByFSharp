(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_4_B/review/1833696/superluminalsloth/OCaml *)
let pi = 4.0 *. atan 1.0;;
let r = read_float () in
    Printf.printf "%f %f\n" (r*.r*.pi) (2.0*.r*.pi);;
