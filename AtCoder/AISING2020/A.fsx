// https://atcoder.jp/contests/aising2020/tasks/aising2020_a
//[| 5 .. 10 |] |> Array.filter (fun x -> x % 2 = 0) |> Array.length
let solve (l, r, d) =
    [| l .. r |]
    |> Array.filter (fun x -> x % d = 0)
    |> Array.length

[<EntryPoint>]
let main argv =
    stdin.ReadLine().Split()
    |> Array.map int
    |> fun x -> x.[0], x.[1], x.[2]
    |> solve
    |> printfn "%d"
    0
