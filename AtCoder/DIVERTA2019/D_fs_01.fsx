// https://atcoder.jp/contests/diverta2019/submissions/7970640
[<AutoOpen>]
module Program

open System

let read f = stdin.ReadLine() |> f
let reada f = stdin.ReadLine().Split() |> Array.map f
let reads f = stdin.ReadLine().Split() |> Array.toList |> List.map f

[<EntryPoint>]
let main _ =
    let N = read int64
    let M = (float >> sqrt >> int64) N

    let ms =
        [1L..M]
        |> List.filter (fun x -> N % x = 0L)
        |> List.collect (fun x -> [x; N / x])
        |> List.map (fun x -> x - 1L)
        |> List.filter ((<>) 0L)
        |> List.distinct

    eprintfn "*%A" ms

    ms
    |> List.filter (fun m -> N / m = N % m)
    |> List.sum
    |> printfn "%i"

    0
