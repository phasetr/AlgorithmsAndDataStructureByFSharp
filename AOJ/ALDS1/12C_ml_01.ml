(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_12_C/review/2460842/rabbisland/OCaml *)
open Printf
open Scanf

module Pqueue = struct
  type 'a t = {mutable cnt : int; hp : 'a array; cmp : 'a -> 'a -> int}
  let create n v f = {cnt = 0; hp = Array.make n v; cmp = f}
  let push k pq =
    let swap i j =
      let t = pq.hp.(i) in
      pq.hp.(i) <- pq.hp.(j);
      pq.hp.(j) <- t in
    let rec iter i =
      let p = i / 2 in
      if p = 0 || pq.cmp pq.hp.(p) pq.hp.(i) >= 0 then ()
      else (swap p i; iter p)
    in
    pq.cnt <- pq.cnt + 1;
    pq.hp.(pq.cnt) <- k;
    iter (pq.cnt)

  let max_heapify pq n =
    let swap i j =
      let t = pq.hp.(i) in
      pq.hp.(i) <- pq.hp.(j);
      pq.hp.(j) <- t in
    let rec iter i =
      let l = 2 * i in
      let r = 2 * i + 1 in
      let mi =
        let ti = if l <= pq.cnt && pq.cmp pq.hp.(l) pq.hp.(i) > 0 then l else i in
        if r <= pq.cnt && pq.cmp pq.hp.(r) pq.hp.(ti) > 0 then r else ti in
      if mi <> i then
        begin
          swap mi i;
          iter mi
        end
    in
    iter n
  let pop pq =
    let ret = pq.hp.(1) in
    pq.hp.(1) <- pq.hp.(pq.cnt);
    pq.cnt <- pq.cnt - 1;
    max_heapify pq 1;
    ret
  let top pq = pq.hp.(1)
  let is_empty pq = pq.cnt = 0
end

let id x = x
let dijkstra g n s =
  let d = Array.make n max_int in
  let av = Array.make n true in
  let pq = Pqueue.create 1000000 (0,0) (fun x y -> compare y x) in
  let rec loop () =
    if Pqueue.is_empty pq then d
    else let du, u = Pqueue.pop pq in
         if av.(u) then begin
             av.(u) <- false;
             List.iter (fun (v, c) ->
                 if du + c < d.(v) then begin
                     d.(v) <- du + c;
                     Pqueue.push (d.(v), v) pq
                   end
               ) g.(u);
             loop ()
           end
         else loop ()
  in
  d.(s) <- 0;
  Pqueue.push (d.(s), s) pq;
  loop ()

let () =
  let n = scanf "%d " id in
  let g = Array.make n [] in
  let rec set_g x =
    if x = 0 then ()
    else let u, k = scanf "%d %d " (fun i j -> (i, j)) in
         let rec read y =
           if y = 0 then set_g (x-1)
           else let vc = scanf "%d %d " (fun i j -> (i, j)) in
                g.(u) <- vc :: g.(u);
                read (y-1)
         in
         read k
  in
  set_g n;
  Array.iteri (fun x y -> printf "%d %d\n" x y) (dijkstra g n 0)
