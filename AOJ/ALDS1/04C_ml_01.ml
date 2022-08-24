(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_4_C/review/2423094/rabbisland/OCaml *)
open Scanf

let () =
  let n = read_int () in
  let dic = Hashtbl.create n in
  let f c a =
    if c = "insert" then Hashtbl.add dic a true
    else if
      try Hashtbl.find dic a with _ -> false then print_endline "yes"
    else print_endline "no" in
  let rec loop x =
    if x = 0 then ()
    else let (c, a) = sscanf (read_line ()) "%s %s" (fun x y -> (x, y)) in
         f c a ; loop (x-1)
  in loop n
