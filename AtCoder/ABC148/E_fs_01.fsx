// https://atcoder.jp/contests/abc148/submissions/9955204
open System

[<EntryPoint>]
let main argv =
    let n = Console.ReadLine() |> int64
    let mutable ans = 0
    let rec solve x d =
        if d > n then x
        else solve (x + n / d) (d * 5L)
    printf "%d" (if n % 2L = 0L then (solve 0L 10L) else 0L)
    0
