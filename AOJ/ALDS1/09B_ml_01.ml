(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_9_B/review/2444479/rabbisland/OCaml *)
open Printf
open Scanf

let id x = x

let max_heapify h ar i =
  let swap i j =
    let t = ar.(i) in
    ar.(i) <- ar.(j);
    ar.(j) <- t in
  let rec iter i =
    let l = 2 * i in
    let r = 2 * i + 1 in
    let mi =
      let ti = if l <= h && ar.(l) > ar.(i) then l else i in
      if r <= h && ar.(r) > ar.(ti) then r else ti in
    if mi <> i then
      begin
        swap mi i;
        iter mi
      end
  in
  iter i

let build_max_heap h ar =
  let rec iter i =
    if i = 0 then ()
    else (max_heapify h ar i;
          iter (i-1))
  in iter (h / 2)

let () =
  let h = scanf "%d\n" id in
  let hp = Array.init (h+1) (fun i -> if i = 0 then 0
                                      else if i = h then let v = scanf "%d\n" id in v
                                      else let v = scanf "%d " id in v) in
  build_max_heap h hp;
  Array.iteri (fun i v -> if i <> 0 then printf " %d" v) hp;
  printf "\n"
