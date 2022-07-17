(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_6_C/review/1855685/superluminalsloth/OCaml *)
let house = Array.init 4 (fun x-> Array.init 3 (fun y -> Array.init 10 (fun z->0) )) and
    s = "####################";;
let n = read_int ();;

let rec read i = match i with
    0 -> ()
  | i -> Scanf.scanf "%d %d %d %d\n" (fun b f r v -> house.(b-1).(f-1).(r-1)<- (house.(b-1).(f-1).(r-1)+v));
         read (i-1) in
    read n;;

let () =
  for i=0 to 3 do
    Array.iter (fun f -> Array.iter (fun r-> Printf.printf " %d" r) f;print_newline ()) house.(i);
    if i < 3 then print_endline s;
  done;
