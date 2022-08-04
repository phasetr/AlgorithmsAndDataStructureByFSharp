(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_11_D/review/2033610/ydash/OCaml *)
type dice = { one : int; two : int; three : int; four : int; five : int; six : int}

type direction = N | S | W | E

let move {one=a;two=b;three=c;four=d;five=e;six=f} = function
  | N -> {one=b;two=f;three=c;four=d;five=a;six=e}
  | S -> {one=e;two=a;three=c;four=d;five=f;six=b}
  | W -> {one=c;two=b;three=f;four=a;five=e;six=d}
  | E -> {one=d;two=b;three=a;four=f;five=e;six=c}

let rec turn_right d = function
  | 0 -> d
  | i -> let {one=a;two=b;three=c;four=d;five=e;six=f} = d in
         turn_right {one=a;two=c;three=e;four=b;five=d;six=f} (i-1)

let all_pattern d =
  List.map
    (fun l -> List.fold_left (fun dice direc -> move dice direc) d l)
    [[];[S];[W];[N];[E];[S;S]]
  |> List.fold_left (fun acc d ->
         List.map
           (fun t -> turn_right d t)
           [0;1;2;3] |> (@) acc) []
let is_same d1 d2 =
  all_pattern d2 |> List.filter (fun x -> x=d1) |> function [] -> false | _ -> true

let () =
  let read_dice n =
    let rec loop ds = function
      | 0 -> ds
      | i ->
         let d = Scanf.scanf "%d %d %d %d %d %d\n" (fun a b c d e f -> {one=a;two=b;three=c;four=d;five=e;six=f}) in
         loop (d::ds) (i-1)
    in loop [] n in
  let list_of_dice = read_dice (read_int ()) in
  let rec check = function
      [] | [_] -> "Yes"
      | hd::tl ->
         match List.filter (is_same hd) tl with
         | [] -> check tl
         | _ -> "No"
  in
  print_endline (check list_of_dice)
