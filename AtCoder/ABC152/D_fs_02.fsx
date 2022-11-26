// https://atcoder.jp/contests/abc152/submissions/9925862
open System
let R T = stdin.ReadLine()|> T
let RS T = stdin.ReadLine().Split()|>Array.map T
let Mod = (1e9|>int64)+7L
[<EntryPoint>]
let main argv =
    let num = [|for i in [0..9] do yield Array.zeroCreate 10|]
    let N = R int
    for i in [1..N] do
        let st = (((i|>string).[0]|>int)-('0'|>int))
        let ed = i%10
        num.[st].[ed] <- num.[st].[ed] + 1L
    [0..9]
    |>Seq.sumBy(fun c -> ([0..9]|>Seq.sumBy(fun d -> num.[c].[d]*num.[d].[c])))
    |>stdout.WriteLine
    0
