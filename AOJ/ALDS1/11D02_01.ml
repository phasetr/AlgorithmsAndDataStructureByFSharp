(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_11_D/review/2458943/rabbisland/OCaml *)
open Printf
open Scanf

let () =
  let n, m = scanf "%d %d " (fun x y -> (x, y)) in
  let g = Array.make n [] in
  let rec set_graph x =
    if x = 0 then ()
    else begin
        let u, v = scanf "%d %d " (fun x y -> (x, y)) in
        g.(u) <- v :: g.(u);
        g.(v) <- u :: g.(v);
        set_graph (x-1)
      end
  in
  let grp = Array.make n 0 in
  let rec set_group i gi =
    let que = Queue.create () in
    let rec iter () =
      if Queue.is_empty que then ()
      else let j = Queue.pop que in
           if grp.(j) <> 0 then iter ()
           else begin
               grp.(j) <- gi;
               List.iter (fun k -> Queue.push k que) g.(j);
               iter ()
             end
    in
    if i = n then ()
    else begin
        Queue.push i que;
        iter ();
        set_group (i+1) (gi+1)
      end
  in
  let rec iter x =
    if x = 0 then ()
    else begin
        let u, v = scanf "%d %d " (fun x y -> (x, y)) in
        printf "%s\n" (if grp.(u) = grp.(v) then "yes" else "no");
        iter (x-1)
      end
  in
  set_graph m;
  set_group 0 1;
  let q = scanf "%d " (fun x -> x) in
  iter q
