#r "nuget: FsUnit"
open FsUnit

(*
let N,Q,Qa = 5,4,[|[|1;4;8|];[|3;2|];[|2|];[|3;2|]|]
*)
let solve N Q (Qa:int[][]) =
  let mutable Aa = Array.init (N+1) id
  let mutable b = true
  Qa |> Array.iter (fun q ->
    if q.[0] = 1 then let x = if b then q.[1] else N-q.[1]+1 in Aa.[x] <- q.[2]
    elif q.[0] = 2 then b <- not b
    else let x = if b then q.[1] else N-q.[1]+1 in stdout.WriteLine Aa.[x])

let N,Q = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
let Qa = Array.init Q (fun _ -> stdin.ReadLine().Split() |> Array.map int)
solve N Q Qa

solve 5 4 [|[|1;4;8|];[|3;2|];[|2|];[|3;2|]|] |> should equal [2;8]
