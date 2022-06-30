(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_2_B/review/2781821/tetrose/OCaml *)
let f a b c = if a < b && b < c then print_string "Yes\n" else print_string "No\n";;
Scanf.sscanf(read_line()) "%d %d %d" f;;
