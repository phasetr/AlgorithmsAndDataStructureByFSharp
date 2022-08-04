(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_11_C/review/4523192/tt99kuze/OCaml *)
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

let () =
  let read () = Scanf.scanf "%d %d %d %d %d %d\n" (fun a b c d e f -> {one = a; two = b; three = c; four = d; five = e; six = f}) in
  let d1 = read () and d2 = read () in
  let all_dices = make_all_dices d2 in
  if check_eq d1 all_dices then print_endline "Yes" else print_endline "No" ;;
