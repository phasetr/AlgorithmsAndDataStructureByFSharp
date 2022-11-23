// https://atcoder.jp/contests/abc112/submissions/9943753
open System

let nm = stdin.ReadLine().Split() |> Array.map int64
let n = nm.[0]
let m = nm.[1]

let mutable ans = 1L
let sqrt = Math.Sqrt(m |> float) |> int64
for d in [1L..sqrt] do
    if (m % d = 0L) && (d * n <= m) then
        ans <- Math.Max(ans, d)
    if (m % d = 0L) && ((m / d) * n <= m) then
        ans <- Math.Max(ans, (m / d))

printfn "%d" ans
