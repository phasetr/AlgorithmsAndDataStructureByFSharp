(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_2_A/review/1829162/superluminalsloth/OCaml *)
let () = Scanf.scanf "%d %d\n"
           (fun x y-> Printf.printf "%s\n"
                        (if x=y then "a == b" else if x>y then "a > b" else "a < b"));;
