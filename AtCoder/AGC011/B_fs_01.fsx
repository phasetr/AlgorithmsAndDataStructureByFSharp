// https://atcoder.jp/contests/agc011/submissions/7991956
[<AutoOpen>]
module Program

open System

let read f = stdin.ReadLine() |> f
let reada f = stdin.ReadLine().Split() |> Array.map f
let reads f = stdin.ReadLine().Split() |> Array.toList |> List.map f

[<EntryPoint>]
let main _ =
    let N = read int64
    let bs = reads int64 |> List.sort
    let cs = List.tail bs
    let ds = List.scan (+) 0L bs |> List.tail

    let es = Seq.zip cs ds |> List.ofSeq

    let mutable ans = 0L
    for x, y in es do
        if x > y * 2L then
            ans <- 0L
        else
            ans <- ans + 1L
    printfn "%i" (ans + 1L)

    0
