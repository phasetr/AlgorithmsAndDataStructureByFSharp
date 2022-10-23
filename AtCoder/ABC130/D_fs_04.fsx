// https://atcoder.jp/contests/abc130/submissions/8082421
[<AutoOpen>]
module Program

open System

let read f = stdin.ReadLine() |> f
let reada f = stdin.ReadLine().Split() |> Array.map f
let reads f = stdin.ReadLine().Split() |> Array.toList |> List.map f

let inline lowerBound (array: ^T []) first last value =
    let rec loop left right =
        if left > right then
            left
        else
            let mid = left + ((right - left) >>> 1)
            if array.[mid] < value then
                loop (mid + 1) right
            else
                loop left (mid - 1)
    loop first (last - 1)

[<EntryPoint>]
let main _ =
    let [N;K] = reads int64
    let AS = reada int64
    let bs = Array.scan (+) 0L AS

    let mutable ans = 0L
    for i in [0 .. int N] do
        let m = lowerBound bs i bs.Length (bs.[i] + int64 K)
        let d = int N + 1 - m
        ans <- ans + int64 d

    printfn "%i" ans
    0
