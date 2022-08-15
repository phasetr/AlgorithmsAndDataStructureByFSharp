(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_3_C/review/5490074/que0/OCaml *)
(* cheat solution *)
open List
let ls = ref []
let rlsb = [("-1", ref true)]
let rls = ref rlsb

let n = read_int ();;
for i = 1 to n do
  match read_line () with
  | "deleteFirst" -> (snd (hd !ls) := false; ls := tl !ls)
  | "deleteLast" -> (
    if fst (find (fun (_, l) -> !l) !rls) = "-1"
    then (
      ls := (filter (fun (_, l) -> !l) !ls);
      rls := rev_append !ls rlsb );
    snd (find (fun (_, l) -> !l) !rls) := false; rls := tl !rls;
    snd (hd rlsb) := true )
  | cmd ->
    try
      match Scanf.sscanf cmd "%c%s %s" (fun a _ b -> a, b) with
      | 'i', x -> ls := (x, ref true) :: !ls
      | 'd', x -> (assoc x !ls := false; ls := remove_assoc x !ls)
      | y, x -> ()
    with Not_found -> ()
done;;
print_endline @@ String.concat " " (map fst (filter (fun (_, l) -> !l) !ls))
