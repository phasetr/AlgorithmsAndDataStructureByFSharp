open Printf
open Scanf

let id x = x
let solve qs =
  let rec setQueen i j qs =
    if i=8 then qs
    else
      if List.mem i (List.map fst qs) then setQueen (i+1) 0 qs
      else
        if j=8 then let (i0,j0) = List.hd qs in setQueen i0 (j0+1) (List.tl qs)
        else if List.mem j (List.map snd qs) ||
                  List.exists (fun (x,y) -> x+y=i+j) qs ||
                    List.exists (fun (x,y) -> x-y=i-j) qs then setQueen i (j+1) qs
        else setQueen (i+1) 0 ((i,j) :: qs) in
  let bd = Array.init 8 (fun _ -> "........") in
  setQueen 0 0 qs
  |> List.iter (fun (r, c) ->
         let s = String.mapi (fun i x -> if i = c then 'Q' else x) bd.(r) in
         bd.(r) <- s);
  bd;;

let n = scanf "%d " id;;
let rec read ls x = if x = 0 then ls else let p = scanf "%d %d " (fun i j -> (i, j)) in read (p::ls) (x-1);;
let qs = read [] n;;
solve qs |> Array.iter (fun s -> printf "%s\n" s);;

solve [(2,2);(5,3)] |> Array.iter (fun s -> printf "%s\n" s)
