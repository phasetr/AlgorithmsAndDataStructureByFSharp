(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_4_C/review/2053787/ydash/OCaml *)
let () =
  let n = read_int () in
  let tbl = Hashtbl.create 1000000 in
  for i=1 to n do
    begin match Scanf.scanf "%s %s\n" (fun a b -> a,b) with
    | "insert",word -> Hashtbl.add tbl word 0
    | _,word -> Printf.printf "%s\n" (if Hashtbl.mem tbl word then "yes" else "no")
    end
  done
