#r "nuget: FsUnit"
open FsUnit

let N,M,Aa = 3,100,[|(1,2);(2,3)|]
let N,M,Aa = 4,100,[|(1,2);(1,3);(1,4)|]
let N,M = 99170,997895651L
"""TODO cf. V05.py, P01.fsx
簡単なテストケースは通るが,
例えば1_13でresにマイナスの値が出てくるのでMODに関わる算数部分で何かおかしい.
"""
let solve N M Aa =
    let mutable G = Array.create N List.empty<int>
    for (x,y) in Aa do
        G.[x-1] <- G.[x-1] @ [y-1]
        G.[y-1] <- G.[y-1] @ [x-1]
    for i in 1..(N-1) do G.[i] <- List.rev G.[i]

    let mutable res = Array.create N 1L
    let mutable L   = Array.create N [1L]
    let mutable R   = Array.create N [1L]

    let rec dfs i p =
        G.[i] <- [for j in G.[i] do if j<>p then yield j]
        // filterでいいのでは?
        for j in G.[i] do
            L.[i] <- L.[i] @ [(L.[i].[List.length L.[i] - 1] * (dfs j i + 1L))%M]
        for j in (List.rev G.[i]) do
            R.[i] <- R.[i] @ [(R.[i].[List.length R.[i] - 1] * (res.[j] + 1L)%M)]
        R.[i] <- List.rev R.[i]
        res.[i] <- List.last L.[i]
        res.[i]

    let rec bfs i x =
        for idx in 0..(List.length G.[i]-1) do
            let y = (x * L.[i].[idx] * R.[i].[idx+1] + 1L)%M
            //let y0 = if 0L <= y then y else (y+M)%M
            //let y = (((((x % M) * (L.[i].[idx] % M)) * (R.[i].[idx] % M)) % M) + 1L) % M
            let j = G.[i].[idx]
            res.[j] <- (res.[j]*y)%M
            //res.[j] <- (res.[j]*y0)%M
            bfs j y
    dfs 0 -1 |> ignore
    bfs 0 1L
    res
let N,M = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0], x.[1])
let Aa = [| for i in 1..(N-1) do (stdin.ReadLine().Split() |> Array.map int |> fun x -> x.[0],x.[1]) |]
solve N M Aa |> Array.map stdout.WriteLine

solve 3 100L [|(1,2);(2,3)|] |> should equal [|3L;4L;3L|]
solve 4 100L [|(1,2);(1,3);(1,4)|] |> should equal [|8L;5L;5L;5L|]
solve 1 100L [||] |> should equal [|1L|]
solve 10 2L [|(8,5);(10,8);(6,5);(1,5);(4,8);(2,10);(3,6);(9,2);(1,7)|] |> should equal  [|0L;0L;1L;1L;1L;0L;1L;0L;1L;1L|]
