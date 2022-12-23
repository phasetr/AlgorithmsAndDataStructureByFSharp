// https://atcoder.jp/contests/abc147/submissions/8888415
[<AutoOpen>]
module Program

open System

let read f = stdin.ReadLine() |> f
let reads f = stdin.ReadLine().Split() |> Array.map f

let MOD = 1000000007L

[<EntryPoint>]
let main _ =
    let N = read int64
    let AS = reads int64

    let ds = Array.create 62 0L
    let f n =
        for i in 0 .. 61 do
            let mask = 1L <<< i
            if n &&& mask <> 0L then
                ds.[i] <- ds.[i] + 1L

    Array.iter f AS

    let pow2 = Array.scan ( * ) 1L (Array.replicate 61 2L)

    let mutable ans = 0L
    for i in 0 .. 61 do
        let one = ds.[i]
        let zero = N - one
        let add = ((zero * one) % MOD) * (pow2.[i] % MOD)
        ans <- (ans + add) % MOD

    printfn "%i" ans
    0
