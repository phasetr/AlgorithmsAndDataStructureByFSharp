(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_9_B/review/1855945/superluminalsloth/OCaml *)
let rec loop u =
  let line = read_line () in
  if line = "-" then ()
  else
    let m = read_int () in
    let rec read s i = match i with
      | 0 -> print_endline s
      | i -> (let h =read_int () in
              read ((String.sub s h ((String.length s)-h))^(String.sub s 0 h)) (i-1))
    in read line m;loop u;;

let () = loop ();;
