(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_3_B/review/3730262/Umyy/OCaml *)
let rec case i =
  match read_int() with
  | 0 -> ()
  | x -> Printf.printf "Case %d: %d\n" i x;
  case (i + 1) in case 1;;
