// https://atcoder.jp/contests/abc133/submissions/15209267
open System

let N  = Console.ReadLine () |> int
let Ai = Console.ReadLine () |> fun s -> s.Split(' ') |> Seq.map int
let M1 = Ai |> Seq.zip (seq { 0 .. N }) |> Seq.sumBy (fun (i, e) -> e * (if i % 2 = 0 then 1 else -1))
let Mi = Ai |> Seq.scan (fun Mb a -> 2 * a - Mb) M1 |> Seq.take N
for M in Mi do  printfn "%i" M
