@"https://atcoder.jp/contests/agc002/tasks/agc002_a
問題文
整数 a，b (a≤b) が与えられます。
a，a+1，...，b すべての積が、正か、負か、0 かを判定してください。

制約
a，b は整数である。
−10^9≤a≤b≤10^9

部分点
100 点分のデータセットでは、−10≤a≤b≤10 が成り立つ。"
#r "nuget: FsUnit"
open FsUnit

let solve a b =
    match (a>0L, b>0L) with
    | (true,true) -> "Positive"
    | (false, true) -> "Zero"
    | _ ->
        if b = 0L then "Zero"
        elif (b-a+1L) % 2L = 0L then "Positive" // 負の数の個数が偶数個
        else "Negative"
let a, b = stdin.ReadLine().Split() |> Array.map int64 |> (fun x -> x.[0], x.[1])
solve a b |> printfn "%s"

solve 1L 3L |> should equal "Positive"
solve -3L -1L |> should equal "Negative"
solve -1L 1L |> should equal "Zero"
solve -2L -1L |> should equal "Positive"
