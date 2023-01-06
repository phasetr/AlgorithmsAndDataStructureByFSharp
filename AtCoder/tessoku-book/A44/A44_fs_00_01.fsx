#r "nuget: FsUnit"
open FsUnit

(*
let N,Q,Qa = 5,4,[|[|1;4;8|];[|3;2|];[|2|];[|3;2|]|]
*)
let solve N Q (Qa:int[][]) =
  (([], true, Array.init (N+1) id), Qa)
  ||> Array.fold (fun (acc,b,Aa) q ->
    if q.[0] = 1 then let x = if b then q.[1] else N-q.[1]+1 in Aa.[x] <- q.[2]; (acc,b,Aa)
    elif q.[0] = 2 then (acc, not b, Aa)
    else let x = if b then q.[1] else N-q.[1]+1 in (Aa.[x]::acc, b, Aa))
  |> fun (acc,_,_) -> List.rev acc

let N,Q = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
let Qa = Array.init Q (fun _ -> stdin.ReadLine().Split() |> Array.map int)
solve N Q Qa |> List.iter stdout.WriteLine

solve 5 4 [|[|1;4;8|];[|3;2|];[|2|];[|3;2|]|] |> should equal [2;8]
