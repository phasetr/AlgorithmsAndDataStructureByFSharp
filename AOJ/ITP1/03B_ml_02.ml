(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_3_B/review/1833303/superluminalsloth/OCaml *)
let rec read i =
  match Scanf.scanf "%d\n" (fun x->x) with
    0 -> ()
  | n -> Printf.printf "Case %d: %d\n" i n; read (i+1);;
let () = read 1;;
