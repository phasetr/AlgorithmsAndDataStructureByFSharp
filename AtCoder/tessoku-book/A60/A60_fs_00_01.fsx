#r "nuget: FsUnit"
open FsUnit

(*
let N,Aa = 6,[|6;2;5;3;1;4|]
*)
let solve N Aa =
  let rec proc (z,ys) (a,d) =
    match ys with
      | [] -> (-1, [(a,d)])
      | (x0,d0)::xs -> if a<x0 then (d0,(a,d)::ys) else proc (0,xs) (a,d)
  Aa |> Array.mapi (fun i a -> (a,i+1))
  |> Array.scan proc (0,[])
  |> Array.map fst |> Array.tail

let N = stdin.ReadLine() |> int
let Aa = stdin.ReadLine().Split() |> Array.map int
solve N Aa |> Array.map string |> String.concat " " |> stdout.WriteLine

solve 6 [|6;2;5;3;1;4|] |> should equal [|-1;1;1;3;4;3|]
