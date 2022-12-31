#r "nuget: FsUnit"
open FsUnit

(*
let N,S,Aa = 3,7,[|2;2;3|]
let N,S,Aa = 4,11,[|3;1;4;5|]
*)
let solve N S Aa =
  (Aa |> Array.head |> Set.singleton, Array.tail Aa)
  ||> Array.fold (fun St a ->
    (St,St) ||> Set.fold (fun st0 v ->
      let st = if S<a then st0 else (Set.add a st0)
      if S<a+v then st else (Set.add (a+v) st)))
  |> Set.contains S |> fun b -> if b then "Yes" else "No"

let N,S = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
let Aa = stdin.ReadLine().Split() |> Array.map int
solve N S Aa |> stdout.WriteLine

solve 3 7 [|2;2;3|] |> should equal "Yes"
solve 4 11 [|3;1;4;5|] |> should equal "No"

pown 2I 60
