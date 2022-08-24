(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_4_C/review/2008131/superluminalsloth/OCaml *)
let () =
  let hash = Hashtbl.create 1000000 in
  let n = read_int () in
  let rec read = function
    | 0 -> ()
    | i ->
       let (op, key) = Scanf.scanf "%s %s\n" (fun x y -> (x,y)) in
       if op = "insert" then
         Hashtbl.add hash key key
       else
         if Hashtbl.mem hash key then Printf.printf "%s\n" "yes"
         else Printf.printf "%s\n" "no"
       ;read (i-1)
  in read n;;
