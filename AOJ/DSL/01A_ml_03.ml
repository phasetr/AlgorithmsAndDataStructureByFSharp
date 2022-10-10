(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/DSL_1_A/review/2481746/rabbisland/OCaml *)
open Printf
open Scanf

module Uftree =
  struct
    type t = int array
    let create n : t = Array.make n (-1)
    let rec find (uft : t) x =
      let p = uft.(x) in
      if p < 0 then x
      else
        let rt = find uft p in
        uft.(x) <- rt; rt
    let unite (uft : t) x y =
      let rx = find uft x in
      let ry = find uft y in
      if rx = ry then ()
      else
        if uft.(rx) < uft.(ry) then
          begin
            uft.(rx) <- uft.(rx) + uft.(ry);
            uft.(ry) <- rx
          end
        else
          begin
            uft.(ry) <- uft.(rx) + uft.(ry);
            uft.(rx) <- ry
          end
    let same (uft : t) x y =
      let rx = find uft x in
      let ry = find uft y in
      rx = ry
    let size (uft : t) x =
      let rx = find uft x in -uft.(rx)
  end

let tuple x y = (x, y)

let () =
  let n, q = scanf "%d %d " tuple in
  let uft = Uftree.create n in
  let rec loop x =
    if x = 0 then ()
    else
      let com, a, b = scanf "%d %d %d " (fun i j k -> (i, j, k)) in
      if com = 0 then
        Uftree.unite uft a b
      else
        (if Uftree.same uft a b then 1 else 0) |> printf "%d\n";
      loop (x-1)
  in loop q
