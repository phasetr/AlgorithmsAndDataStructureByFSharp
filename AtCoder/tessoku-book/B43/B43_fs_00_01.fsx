#r "nuget: FsUnit"
open FsUnit

(*
let N,M,Aa = 4,6,[|1;4;1;4;2;1|]
*)
let solve N M Aa =
  Array.create N 0
  |> fun Ca -> Aa |> Array.iter (fun a -> Ca.[a-1] <- Ca.[a-1]+1); Ca
  |> Array.map (fun c -> M-c)

let N,M = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
let Aa = stdin.ReadLine().Split() |> Array.map int
solve N M Aa |> Array.iter stdout.WriteLine

solve 4 6 [|1;4;1;4;2;1|] |> should equal [|3;5;6;4|]
