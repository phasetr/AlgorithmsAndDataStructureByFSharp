// https://atcoder.jp/contests/abc172/tasks/abc172_a
[<EntryPoint>]
let main argv =
    stdin.ReadLine()
    |> int
    |> fun x -> x  + x*x + x*x*x
    |> printfn "%d"
    0
