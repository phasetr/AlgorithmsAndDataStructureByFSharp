#r "nuget: FsUnit"
open FsUnit

let K,T,Aa = 7,3,[|3;2;2|]
let solve K T Aa = let m = Array.max Aa in max (m-1-(K-m)) 0

let K,T = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
let Aa = stdin.ReadLine().Split() |> Array.map int
solve K T Aa |> stdout.WriteLine

solve 7 3 [|3;2;2|] |> should equal 0
solve 6 3 [|1;4;1|] |> should equal 1
solve 100 1 [|100|] |> should equal 99
