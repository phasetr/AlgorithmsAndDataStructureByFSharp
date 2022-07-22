(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_8_B/review/5473857/que0/OCaml *)
let s = ref "" ;;
while (s := read_line (); !s <> "0") do
  let a = ref 0 in
  String.iter (fun c -> a:=!a+ + String.index_from "0123456789" 0 c) !s;
  Printf.printf "%d\n" !a
done
