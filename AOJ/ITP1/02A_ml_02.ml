(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_2_A/review/1998066/r6eve/OCaml *)
Scanf.scanf"%d %d"(fun a b->print_endline("a "^[|"<";"==";">"|].(compare a b+1)^" b"))
