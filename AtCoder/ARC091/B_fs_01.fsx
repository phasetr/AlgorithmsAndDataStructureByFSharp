// https://atcoder.jp/contests/abc090/submissions/2234684
open System

let N,K =
    let t = Console.ReadLine().Split()
            |> Array.map(int)
    t.[0],t.[1]

[K+1..N]
|> List.map(fun b ->
    (int64 <|
        let e = N % b
        let p = N / b
        let r =
           if   K = 0  then e
           elif e >= K then e - K + 1
           else             0
        (b - K) * p + r))
|> List.sum
|> printfn "%i"
