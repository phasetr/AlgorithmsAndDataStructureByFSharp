#r "nuget: FsUnit"
open FsUnit
let N,K,Aa = 2,4,[|2;3|]
let solve N K Aa =
    (Array.zeroCreate (K+1), [|1..K|])
    ||> Array.fold (fun dp i -> Array.set dp i (1 - (Array.fold (fun s w -> if w<=i then min s dp.[i-w] else s) 1 Aa)); dp)
    |> fun dp -> if dp.[K]=1 then "First" else "Second"
let N,K = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0], x.[1])
let Aa = stdin.ReadLine().Split() |> Array.map int
solve N K Aa |> stdout.WriteLine

solve 2 4 [|2;3|] |> should equal "First"
solve 2 5 [|2;3|] |> should equal "Second"
solve 2 7 [|2;3|] |> should equal "First"
solve 3 20 [|1..3|] |> should equal  "Second"
solve 3 21 [|1..3|] |> should equal "First"
solve 1 100000 [|1|] |> should equal "Second"
