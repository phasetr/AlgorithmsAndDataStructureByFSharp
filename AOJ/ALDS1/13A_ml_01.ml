(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_13_A/review/2466803/rabbisland/OCaml *)
open Printf
open Scanf

let id x = x
let () =
  let n = scanf "%d " id in
  let rec read ls x = if x = 0 then ls else let p = scanf "%d %d " (fun i j -> (i, j)) in read (p::ls) (x-1) in
  let ps = read [] n in
  let rec loop i j ls =
    if i = 8 then ls
    else
      if List.mem i (List.map fst ls) then loop (i+1) 0 ls
      else
        if j = 8 then let p = List.hd ls in loop (fst p) ((snd p) + 1) (List.tl ls)
        else if List.mem j (List.map snd ls) ||
                  List.exists (fun (x, y) -> x + y = i + j) ls ||
                    List.exists (fun (x, y) -> x - y = i - j) ls then loop i (j+1) ls
        else loop (i+1) 0 ((i, j) :: ls) in
  let bd = Array.init 8 (fun _ -> "........") in
  List.iter (fun (r, c) ->
      let s = String.mapi (fun i x -> if i = c then 'Q' else x) bd.(r) in
      bd.(r) <- s)
    (loop 0 0 ps);
  Array.iter (fun s -> printf "%s\n" s) bd
