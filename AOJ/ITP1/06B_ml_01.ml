(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_6_B/review/1839290/superluminalsloth/OCaml *)
let () =
  let s = ["D";"C";"H";"S"] in
  let r = [1;2;3;4;5;6;7;8;9;10;11;12;13] in
  let sr = List.fold_left (fun x y -> (List.map (fun e-> (y,e)) r)@x) [] s in
  let n = read_int () in
  let rec read i =
    match i with
    | i when i = n -> []
    | _ ->
       let p = Scanf.scanf "%s %d\n" (fun x y->(x,y)) in
       p::read (i+1)
  in
  let l = read 0 in
  let to_string (x,y) = x^" "^(string_of_int y) in
  let in_list x = List.exists (fun e -> x=e) l in
  List.fold_left (fun x y -> if in_list y then x else x^(to_string y)^"\n") "" sr |> print_string;;
