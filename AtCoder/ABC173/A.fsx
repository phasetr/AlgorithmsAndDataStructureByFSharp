// https://atcoder.jp/contests/abc173/tasks/abc173_a
let solve n = (10000 - n) % 1000
//solve 1900
//solve 3000

[<EntryPoint>]
let main argv =
    stdin.ReadLine() |> int |> solve |> printfn "%d"
    0
