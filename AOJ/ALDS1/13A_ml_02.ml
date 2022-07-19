(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_13_A/review/2448835/r6eve/OCaml *)
let iota ?(start=0) ?(step=1) cnt =
  let rec doit i acc =
    if i <= 0 then acc
    else doit (i - 1) (start + step*(i - 1) :: acc) in
  doit cnt []

let safe_p p qs =
  let rec doit i = function
    | [] -> true
    | q :: qs ->
       if p = q + i || p = q - i then false
       else doit (i + 1) qs in
  doit 1 qs

let answer_p rc qs =
  let rec doit i = function
    | ([], _) -> true
    | (_, []) -> assert false
    | ((r, c) :: xs as rc, q :: qs) ->
       if r <> i then doit (i + 1) (rc, qs)
       else if c = q then doit (i + 1) (xs, qs)
       else false in
  doit 0 (rc, qs)

let print qs =
  List.iter (fun q ->
      for i = 0 to 7 do
        print_string (if i = q then "Q" else ".")
      done;
      print_newline ()) qs

let () =
  let k = read_int () in
  let rec read i rc =
    if i = k then rc
    else read (i + 1) (Scanf.scanf "%d %d\n" (fun r c -> (r, c)) :: rc) in
  let rc = read 0 [] |> List.sort (fun (a, _) (b, _) -> a - b) in
  let rec doit qs = function
    | [] -> if answer_p rc qs then print qs
    | ps ->
       List.iter (fun p ->
           if safe_p p qs then List.filter (fun e -> e <> p) ps |> doit (p :: qs))
         ps in
  iota 8 |> doit []
