(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_11_D/review/4524048/tt99kuze/OCaml *)
type dice = {one : int ; two : int ; three : int ; four : int ; five : int ; six : int };;
type dir = W | E | S | N | L | R ;;

let roll dice =
  let {one = a; two = b; three = c; four = d; five = e; six = f} = dice in
  function
  | W -> {dice with one = c; three = f; six = d; four = a}
  | E -> {dice with one = d; four = f; six = c; three = a}
  | S -> {dice with one = e; two = a; six = b; five = f}
  | N -> {dice with one = b; two = f; six = e; five = a}
  | L -> {dice with two = c; three = e; five = d; four = b}
  | R -> {dice with two = d; four = e; five = c; three = b} ;;

let dir_list1 = [[];[W];[E];[S];[N];[W; W]];;
let dir_list2 = [[];[L];[R];[L;L]] ;;

let make_all_dices dice =
  let f d lst = List.fold_left (fun e dir -> roll e dir) d lst in
  let dice_list = List.map (f dice) dir_list1 in
  List.map (fun x -> List.map (f x) dir_list2) dice_list |> List.concat ;;

let check_eq dice list =
  List.exists (fun x -> x = dice) list ;;

let rec check_same_dices_exist = function
  | [] -> false
  | x::xs ->
     let rec f a = function
       | [] -> false
       | y :: ys -> check_eq x (make_all_dices y) || f x ys in
     f x xs || check_same_dices_exist xs ;;

let () =
  let n = Scanf.scanf "%d\n" (fun a -> a) in
  let as_ = Array.init n (fun _ -> Scanf.scanf "%d %d %d %d %d %d\n" (fun a b c d e f -> {one = a; two = b; three = c; four = d; five = e; six = f})) in
  let as_list = Array.to_list as_ in
  if not (check_same_dices_exist as_list) then print_endline "Yes" else print_endline "No";;
