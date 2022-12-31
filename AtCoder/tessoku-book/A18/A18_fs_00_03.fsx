#r "nuget: FsUnit"
open FsUnit

(*
let N,S,Aa = 3,7,[|2;2;3|]
let N,S,Aa = 4,11,[|3;1;4;5|]
let N,S,Aa = 12,469,[|24;156;62;156;42;159;27;21;141;142;45;146|]
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
  Aa
  |> Array.filter (fun a -> a<=S)
  |> fun Aa ->
    if Array.isEmpty Aa then "No"
    else frec (Array.tail Aa) (Aa |> Array.head |> Set.singleton)

let N,S = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
let Aa = stdin.ReadLine().Split() |> Array.map int
solve N S Aa |> stdout.WriteLine

solve 3 7 [|2;2;3|] |> should equal "Yes"
solve 4 11 [|3;1;4;5|] |> should equal "No"
// 02_subtask1_random01.txt
solve 12 469 [|24;156;62;156;42;159;27;21;141;142;45;146|] |> should equal "Yes"
