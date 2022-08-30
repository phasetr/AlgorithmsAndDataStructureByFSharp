(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_6_C/review/2431781/rabbisland/OCaml *)
open Printf
open Scanf

type card = {suit : string; value : int}

let id x = x

let partition cmp a p r =
  let swap i j =
    let t = a.(i) in
    a.(i) <- a.(j);
    a.(j) <- t in
  let x = a.(r) in
  let rec iter i j =
    if j = r then begin swap (i+1) r; i+1 end
    else if cmp a.(j) x <= 0 then
      let ii = i+1 in
      swap ii j;
      iter ii (j+1)
    else iter i (j+1) in
  iter (p-1) p

let rec quick_sort cmp a p r =
  if p >= r then ()
  else let q = partition cmp a p r in
       quick_sort cmp a p (q-1);
       quick_sort cmp a (q+1) r

let () =
  let n = scanf "%d\n" id in
  let ar = Array.init n (fun _ -> scanf "%s %d\n" (fun x y -> {suit = x; value = y})) in
  let ar2 = Array.copy ar in
  quick_sort (fun x y -> compare x.value y.value) ar 0 (n-1);
  Array.stable_sort (fun x y -> compare x.value y.value) ar2;
  printf "%s\n" (if ar = ar2 then "Stable" else "Not stable");
  Array.iter (fun x -> printf "%s %d\n" x.suit x.value) ar
