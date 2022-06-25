(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_12_B/review/2460093/rabbisland/OCaml *) 
open Printf
open Scanf

let id x = x

let dijkstra g n s =
  let d = Array.make n max_int in
  let av = Array.make n true in
  let rec min_cost i r =
    if i = n then r
    else if av.(i) then begin
        match r with
          None -> min_cost (i+1) (Some i)
        | Some j -> if d.(i) < d.(j) then
                      min_cost (i+1) (Some i)
                    else
                      min_cost (i+1) r
      end
    else min_cost (i+1) r
  in
  let rec loop () =
    match min_cost 0 None with
      None -> d
    | Some u -> begin
        av.(u) <- false;
        Array.iteri (fun v w ->
                     if w >= 0 && av.(v) then
                       if d.(u) + w < d.(v) then
                         d.(v) <- d.(u) + w
                    ) g.(u);
        loop ()
      end
  in
  d.(s) <- 0;
  loop ()

let () =
  let n = scanf "%d " id in
  let g = Array.make_matrix n n (-1) in
  let rec set_g x =
    if x = 0 then ()
    else let u, k = scanf "%d %d " (fun i j -> (i, j)) in
         let rec read y =
           if y = 0 then set_g (x-1)
           else let v, c = scanf "%d %d " (fun i j -> (i, j)) in
                g.(u).(v) <- c;
                read (y-1)
         in
         read k
  in
  set_g n;
  Array.iteri (fun x y -> printf "%d %d\n" x y) (dijkstra g n 0)
