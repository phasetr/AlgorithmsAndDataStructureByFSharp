// https://atcoder.jp/contests/abc094/submissions/24802917
let N = stdin.ReadLine() |> int
let A = stdin.ReadLine().Split() |> Array.map int64 |> Array.sort

[|for i in A -> (i,((i |> float) / (Array.last A |> float) - 0.5) |> abs)|]
|> Array.sortBy (snd)
|> fun x ->
    printfn "%d %d" (Array.last A) (fst x.[0])
