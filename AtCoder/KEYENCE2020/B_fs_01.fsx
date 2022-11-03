// https://atcoder.jp/contests/keyence2020/submissions/24635287
let N = stdin.ReadLine() |> int
let Arm =
    [|
        for i in 1..N ->
            stdin.ReadLine().Split()
            |>Array.map int
    |]
    |> Array.sortBy (Array.sum)

let mutable Max = Array.sum Arm.[0]
let mutable ans = N

for i in 1..N-1 do
    if Max <= Arm.[i].[0] - Arm.[i].[1] then
        Max <- Array.sum Arm.[i]
    else ans <- ans - 1

printfn "%d" ans
