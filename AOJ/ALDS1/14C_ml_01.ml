(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_14_C/review/2473187/rabbisland/OCaml *)
open Scanf
open Printf

let id x = x
let tuple x y = (x, y)

let calc_rh a h w r c =
  let bh = 10007 in
  let bv = 999983 in
  let rec pow x n =
    if n = 0 then 1
    else if n mod 2 = 0 then let y = pow x (n / 2) in y * y
    else x * pow x (n-1) in
  let rh a b i j =
    let rec iter r k =
      if k = j then r
      else iter (r * b + a.(k)) (k+1) in
    iter 0 i
  in
  let bh' = pow bh c in
  let ta = Array.make_matrix h (w - c + 1) 0 in
  let rec set_ta i j =
    if i = h then ()
    else if j = w - c + 1 then set_ta (i+1) 0
    else begin
        if j = 0 then ta.(i).(j) <- rh a.(i) bh 0 c
        else ta.(i).(j) <- ta.(i).(j-1) * bh + a.(i).(j+c-1) - a.(i).(j-1) * bh';
        set_ta i (j+1)
      end
  in
  let bv' = pow bv r in
  let rht = Array.make_matrix (h - r + 1) (w - c + 1) 0 in
  let rec set_rht i j =
    if j = w - c + 1 then ()
    else if i = h - r + 1 then set_rht 0 (j+1)
    else begin
        if i = 0 then rht.(i).(j) <- rh (Array.init r (fun k -> ta.(k).(j))) bv 0 r
        else rht.(i).(j) <- rht.(i-1).(j) * bv + ta.(i+r-1).(j) - ta.(i-1).(j) * bv';
        set_rht (i+1) j
      end
  in
  set_ta 0 0;
  set_rht 0 0;
  rht

let () =
  let h, w = scanf "%d %d " tuple in
  let fld = Array.init h (fun _ ->
                let s = scanf "%s " id in
                Array.init w (fun i ->
                    Char.code s.[i]
                  )
              ) in
  let r, c = scanf "%d %d " tuple in
  let ptn = Array.init r (fun _ ->
                let s = scanf "%s " id in
                Array.init c (fun i ->
                    Char.code s.[i]
                  )
              ) in
  let ft = calc_rh fld h w r c in
  let pt = calc_rh ptn r c r c in
  let rec loop i j =
    if i = h - r + 1 then ()
    else if j = w - c + 1 then loop (i+1) 0
    else begin
        if ft.(i).(j) = pt.(0).(0) then printf "%d %d\n" i j;
        loop i (j+1)
      end
  in
  loop 0 0
