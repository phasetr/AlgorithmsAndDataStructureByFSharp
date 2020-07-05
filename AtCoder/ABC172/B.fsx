// https://atcoder.jp/contests/abc172/tasks/abc172_b
let s = "cupofcoffee"
let t = "cupofhottea"
Seq.map2 (fun x y -> if x <> y then 1 else 0) s t
|> Seq.sum

[<EntryPoint>]
let main argv =
    let s = stdin.ReadLine()
    let t = stdin.ReadLine()
    Seq.map2 (fun x y -> if x <> y then 1 else 0) s t
    |> Seq.sum
    |> printfn "%d"
    0
