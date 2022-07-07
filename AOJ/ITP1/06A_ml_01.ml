(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_6_A/review/2782125/tetrose/OCaml *)
let rec make_rev n l =
  match n with
  | 0 -> l
  | _ -> Scanf.scanf " %d" (fun x -> make_rev (n-1) (x::l));;

let rec print_list l =
  match l with
  | [] -> print_string "\n"
  | x::xs -> print_int x; if xs <> [] then print_string " ";print_list xs;;

let n = Scanf.sscanf(read_line()) "%d" (fun x -> x) in
    print_list (make_rev n []);;

