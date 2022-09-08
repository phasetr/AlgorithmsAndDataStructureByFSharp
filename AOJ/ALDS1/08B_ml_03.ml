(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_8_B/review/5529753/que0/OCaml *)
type 'a wood = {key: int; mutable p: 'a; mutable left: 'a; mutable right: 'a};;
type tree = Nil | Tree of tree wood;;

let insert t zw = (
  let y = Nil in
  let x = t in
  let rec i_while x y =
    match x with
    | Tree xw ->
      let y = x in
      if zw.key < xw.key
      then i_while xw.left y
      else i_while xw.right y
    | Nil -> y in
  let y = i_while x y in (
  zw.p <- y;
  match y with
  | Nil -> Tree zw
  | Tree yw -> (
    (if zw.key < yw.key
     then yw.left <- Tree zw
     else yw.right <- Tree zw);
    t ) ) )
;;
type ud = Up | Dn

let walk_print t p d f1 f2 f3 =
  let rec walk t p d =
    match t, p, d with
    | Nil, Nil, _ -> ()
    | Nil, _, Up -> ()
    | Nil, p, Dn -> walk p Nil Up
    | Tree tw, p, Dn -> (f1 tw.key; walk tw.left t Dn)
    | Tree tw, p, Up ->
      match tw.left, tw.right with
      | Nil, Nil -> (f2 tw.key; f3 tw.key; walk tw.p t Up)
      | otherwise ->
        if tw.right != p
        then (f2 tw.key; walk tw.right t Dn)
        else (f3 tw.key; walk tw.p t Up) in
  walk t p d;;

let walk_find t v =
  let rec walk t =
    match t with
    | Nil -> "no"
    | Tree tw -> (
      match (compare tw.key v) with
      | 0 -> "yes"
      | a when a > 0 -> walk tw.left
      | a -> walk tw.right ) in
  walk t;;

let t = ref Nil;;
let n = read_int ();;
for i = 1 to n do
  let s = read_line () in
  match (Scanf.sscanf s "%s" (fun x -> x)) with
  | "insert" ->
    t:= insert !t {key = (Scanf.sscanf s "insert %d" (fun x -> x)); p = Nil; left = Nil; right = Nil}
  | "print" -> (
    walk_print !t Nil Dn ignore (Printf.printf " %d") ignore;
    print_newline ();
    walk_print !t Nil Dn (Printf.printf " %d") ignore ignore;
    print_newline () )
  | "find" -> print_endline (walk_find !t (Scanf.sscanf s "find %d" (fun x -> x)))
  | _ -> ()
done
