(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_9_A/review/2444053/rabbisland/OCaml *)
open Printf
open Scanf
let id x = x

let () =
  let h = scanf "%d\n" id in
  let hp = Array.init (h+1)
             (fun i -> if i = 0 then 0
                       else if i = h then let v = scanf "%d\n" id in v
                       else let v = scanf "%d " id in v) in
  Array.iteri
    (fun i v -> if i > 0 then
                  printf "node %d: " i;
                printf "key = %d, " v;
                (let p = i / 2 in if p <> 0 then printf "parent key = %d, " hp.(p));
                (let l = 2 * i in if l <= h then printf "left key = %d, " hp.(l));
                (let r = 2 * i + 1 in if r <= h then printf "right key = %d, " hp.(r));
                printf "\n"
    ) hp
