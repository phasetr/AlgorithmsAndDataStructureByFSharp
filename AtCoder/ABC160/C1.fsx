// https://atcoder.jp/contests/abc160/submissions/11749539
let N, K = stdin.ReadLine().Split() |> Array.map int |> fun x -> x.[0], x.[1]
let A = stdin.ReadLine().Split() |> Array.map int
A
|> Seq.pairwise
|> Seq.map (fun (x, y) -> y - x)
|> Seq.append [ A.[0] + N - A.[K - 1] ]
|> fun x -> (x |> Seq.sum) - (x |> Seq.max)
|> printfn "%d"
