// https://atcoder.jp/contests/abc130/submissions/8083120
[<AutoOpen>]
module Program

open System

let read f = stdin.ReadLine() |> f
let reada f = stdin.ReadLine().Split() |> Array.map f
let reads f = stdin.ReadLine().Split() |> Array.toList |> List.map f

[<EntryPoint>]
let main _ =
    let [N;K] = reads int64
    let AS = reada int64

    let rec loop acc k l r =
        if l >= AS.Length then
            acc
        elif k >= K then
            loop (acc + N - int64 r + 1L) (k - AS.[l]) (l + 1) r
        elif r >= AS.Length then
            acc
        else
            loop acc (k + AS.[r]) l (r + 1)

    loop 0L 0L 0 0
    |> printfn "%i"
    0
