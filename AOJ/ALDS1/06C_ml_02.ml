(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_6_C/review/5517817/que0/OCaml *)
let cc f (_, a) (_, b) = f (compare a b) 0
let card_le = cc (<=)
let card_lt = cc (<)

let rec qsortl f l =
  match l with
  | [] -> []
  | p :: u -> let (s, b) = List.partition (fun x-> f x p) u in
              qsortl f s @ p :: qsortl f b

let asw a i j =
  let b = a.(i) in a.(i) <- a.(j); a.(j) <- b

let partition a p r =
  let x = a.(r) in
  let i = ref (p - 1) in
  for j = p to r - 1 do
    if card_le a.(j) x
    then (i := !i + 1; asw a !i j);
  done;
  asw a (!i+1) r;
  !i+1

let rec quicksort a p r =
  if p < r then
    let q = partition a p r in (
        quicksort a p (q-1);
        quicksort a (q+1) r );;

let n = read_int ()
let a = Array.init n (fun _ -> (Scanf.scanf "%s %d " (fun a b -> a, b)))
let s = Array.of_list (qsortl card_lt (Array.to_list a));;
quicksort a 0 (n-1);
print_endline (if a = s then "Stable" else "Not stable");
Array.iter (fun (a, b) -> Printf.printf "%s %d\n" a b) a
