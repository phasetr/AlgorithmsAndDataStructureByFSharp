// https://atcoder.jp/contests/abc081/submissions/12307380
// シンプルでいい
let rec f x = if x % 2 = 0 then 1 + f (x / 2) else 0

[<EntryPoint>]
let main argv =
    stdin.ReadLine() |> ignore
    stdin.ReadLine().Split()
    |> Array.map (int >> f)
    |> Array.min
    |> printfn "%d"
    0
