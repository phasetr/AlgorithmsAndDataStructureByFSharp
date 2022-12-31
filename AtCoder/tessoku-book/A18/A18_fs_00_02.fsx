#r "nuget: FsUnit"
open FsUnit

(*
let N,S,Aa = 3,7,[|2;2;3|]
let N,S,Aa = 4,11,[|3;1;4;5|]
*)
let solve N S Aa =
  let rec frec Aa St =
    if Set.contains S St then "Yes"
    elif Array.isEmpty Aa then "No"
    else
      let a = Array.head Aa
      (St,St) ||> Set.fold (fun st0 v ->
        let st = if S<a then st0 else (Set.add a st0)
        if S<a+v then st else (Set.add (a+v) st))
      |> frec (Array.tail Aa)
  frec (Array.tail Aa) (Aa |> Array.head |> Set.singleton)

let N,S = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
let Aa = stdin.ReadLine().Split() |> Array.map int
solve N S Aa |> stdout.WriteLine

solve 3 7 [|2;2;3|] |> should equal "Yes"
solve 4 11 [|3;1;4;5|] |> should equal "No"
