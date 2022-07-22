(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_8_C/review/5474166/que0/OCaml *)
open String
let ad = "abcdefghijklmnopqrstuvwxyz"
let aa = Array.make 26 0
let s = ref "";;
while (try s := map Char.lowercase_ascii (read_line ()); true with _ -> false) do
  iter
    (function
     | 'a' .. 'z' as h -> let i = index_from ad 0 h in aa.(i) <- aa.(i)+1
     | x -> ())
    !s
done;;
iteri (fun i c -> Printf.printf "%c : %d\n" c aa.(i)) ad
