(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_8_A/review/5529171/que0/OCaml *)
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

let t = ref Nil;;
let n = read_int ();;
for i = 1 to n do
  let s = read_line () in
  if String.length s >= 6
  then t:= insert !t {key = (Scanf.sscanf s "insert %d" (fun x -> x)); p = Nil; left = Nil; right = Nil}
  else (
    walk_print !t Nil Dn ignore (Printf.printf " %d") ignore;
    print_newline ();
    walk_print !t Nil Dn (Printf.printf " %d") ignore ignore;
    print_newline () )
done
