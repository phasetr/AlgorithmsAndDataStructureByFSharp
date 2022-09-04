(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_7_B/review/2437462/rabbisland/OCaml *)
open Printf
open Scanf

type node = { p : int option; l : int option; r : int option; d : int; h : int}

let id x = x

let parent_of_node = function
    {p = Some x} -> x
  | _ -> (-1)

let sibling_of_node tr i = match tr.(i) with
    {p = Some x} -> let pn = tr.(x) in
                    begin
                      match pn with
                        {l = Some y; r = Some z} when y = i -> z
                      | {l = Some y; r = Some z}  -> y
                      | _ -> (-1)
                    end
  | _ -> (-1)

let degree_of_node = function
    {l = Some _; r = Some _} -> 2
  | {l = Some _} -> 1
  | {r = Some _} -> 1
  | _ -> 0

let type_of_node = function
    {p = None} -> "root"
  | {l = None; r = None} -> "leaf"
  | _ -> "internal node"

let find_root tr =
  let l = Array.length tr in
  let rec iter i =
    if i = l then failwith "find_root"
    else if tr.(i).p = None then i
    else iter (i+1)
  in iter 0

let set_depth tr n =
  let rec iter d = function
      Some x -> tr.(x) <- {tr.(x) with d = d}; iter (d+1) tr.(x).l; iter (d+1) tr.(x).r
    | None -> ()
  in iter 0 (Some n)

let set_height tr n =
  let rec iter = function
      Some x -> let lh = iter tr.(x).l and rh = iter tr.(x).r in
                let h = max lh rh in
                tr.(x) <- {tr.(x) with h = h}; h+1
    | None -> 0
  in
  iter (Some n) |> ignore

let () =
  let n = scanf "%d\n" id in
  let btree = Array.make n {p = None; l = None; r = None; d = 0; h = 0} in
  let rec read n =
    if n = 0 then ()
    else begin
        let i, l, r = scanf "%d %d %d\n" (fun x y z -> (x, y, z)) in
        begin
          btree.(i) <- {btree.(i) with l = (if l <> (-1) then Some l else None);
                                       r = (if r <> (-1) then Some r else None)};
          if l <> (-1) then btree.(l) <- {btree.(l) with p = Some i};
          if r <> (-1) then btree.(r) <- {btree.(r) with p = Some i}
        end;
        read (n-1)
      end
  in
  read n;
  let r = find_root btree in
  set_depth btree r;
  set_height btree r;
  Array.iteri (fun i n ->
      printf "node %d: parent = %d, sibling = %d, degree = %d, depth = %d, height = %d, %s\n"
        i (parent_of_node n) (sibling_of_node btree i) (degree_of_node n)
        (n.d) (n.h) (type_of_node n)
    ) btree
