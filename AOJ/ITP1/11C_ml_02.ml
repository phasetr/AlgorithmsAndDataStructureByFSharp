(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_11_C/review/2033583/ydash/OCaml *)
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

let () =
  let read_dice () = Scanf.scanf "%d %d %d %d %d %d\n"
                       (fun a b c d e f -> {one=a;two=b;three=c;four=d;five=e;six=f}) in
  let d1,d2 = read_dice (), read_dice () in
  let all_pattern =
    List.map
      (fun l -> List.fold_left (fun dice direc -> move dice direc) d2 l) [[];[S];[W];[N];[E];[S;S]]
    |> List.fold_left (fun acc d -> List.map (fun t -> turn_right d t) [0;1;2;3] |> (@) acc) [] in
  all_pattern
  |> List.filter (fun x -> x=d1)
  |> (function [] ->  "No" | _ -> "Yes")
  |> print_endline
