(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/GRL_1_A/review/4469259/mmmohei/OCaml *)
module ArrayL = ArrayLabels
module ListL = ListLabels

let dbg = Printf.printf "[debug]%s"

let max_num = 1_000_000_000

let id = fun x -> x
let tuple2 x y = (x,y)
let tuple3 x y z = (x,y,z)
let succ x = x + 1
let pred x = x - 1

let (++) n m =
  let rec aux i =
    if i = m then [m]
    else i :: aux (i+1) in
  if n > m then [] else aux n

let (++^) n m = n ++ (m-1)

let scan fmt f = Scanf.sscanf (read_line ()) fmt f

let scan_lines n fmt f =
  List.map (fun _ -> scan fmt f) (0++^n)

let scan_matrix n m e conv =
  let arr = Array.make_matrix n m e in
  Array.iteri (fun i line ->
      let s = Scanf.Scanning.from_string @@ read_line () in
      Array.iteri (fun j _ ->
          arr.(i).(j) <- Scanf.bscanf s " %s" conv;
        ) line) arr; arr

let between n x m = n <= x && x < m

let string_to_list s =
  List.map (String.get s) (0 ++^ String.length s)

let (v,e,r) = scan "%d %d %d" tuple3
let ls = scan_lines e "%d %d %d" tuple3
let edges =
  let arr = Array.make v [] in
  ListL.iter ls ~f:(fun (s,t,d)->
      arr.(s) <- (t,d)::arr.(s));
  arr

let dists = Array.make v max_num
let visited = Array.make v false

module Heap = Set.Make(struct
    type t = int*int
    let compare (x0, y0) (x1,y1) =
      match compare y0 y1 with
      | 0 -> compare x0 x1
      | c -> c
  end)

let rec solve h =
  if Heap.is_empty h then ()
  else
    let (t, dist) = Heap.min_elt h in
    if visited.(t) then solve @@ Heap.remove (t, dist) h
    else
      begin
        visited.(t) <- true; dists.(t) <- dist;
        solve @@ ListL.fold_left edges.(t)
          ~init:(Heap.remove (t, dist) h) ~f:(fun h (s, d) ->
              if not visited.(s) then Heap.add (s, dists.(t) + d) h
              else h)
      end

let () =
  solve @@ (Heap.empty |> Heap.add (r,0));
  ArrayL.iter dists ~f:(fun v ->
      if v = max_num then print_string "INF\n"
      else Printf.printf "%d\n" v)
