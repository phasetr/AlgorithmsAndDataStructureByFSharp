// https://atcoder.jp/contests/abc086/tasks/abc086_b
// https://atcoder.jp/contests/abc086/submissions/12246739
open System

[<EntryPoint>]
let main _ =
    let x =
        stdin.ReadLine().Split() |> String.Concat |> int

    let sqrtX = int (x |> float |> sqrt)
    if pown sqrtX 2 = x then stdout.WriteLine "Yes" else stdout.WriteLine "No"
    0
