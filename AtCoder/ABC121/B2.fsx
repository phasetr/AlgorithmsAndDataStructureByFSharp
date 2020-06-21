// https://atcoder.jp/contests/abc121/tasks/abc121_b
// https://atcoder.jp/contests/abc121/submissions/8184998
let N, M, C =
    stdin.ReadLine().Split()
    |> fun c -> int c.[0], int c.[1], int c.[2]

let B =
    stdin.ReadLine().Split() |> Array.map int

let A =
    [ for i in [ 0 .. N - 1 ] do
        yield (stdin.ReadLine().Split() |> Array.map int) ]

[<EntryPoint>]
let main argv =
    let sum =
        [ for i in [ 0 .. N - 1 ] do
            yield ([ 0 .. M - 1 ]
                   |> Seq.sumBy (fun c -> (A.[i].[c] * B.[c]))) ]

    sum
    |> Seq.sumBy (fun s -> if (s + C) > 0 then 1 else 0)
    |> printfn "%d"
    0
