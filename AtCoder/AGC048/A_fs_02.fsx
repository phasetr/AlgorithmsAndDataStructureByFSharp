// https://atcoder.jp/contests/agc038/submissions/8289192
open System.IO
open System

let [| h; w; a; b; |] = stdin.ReadLine().Split() |> Array.map int

//出力
let sw = new StreamWriter(Console.OpenStandardOutput())
sw.AutoFlush <- false
Console.SetOut(sw)

seq{
    for i in 1..b do
        yield new string ([|
            for i in 1..a -> '0'
            for i in 1..w-a -> '1'|]) 
    for i in 1..h-b do
        yield new string ([|
            for i in 1..a -> '1'
            for i in 1..w-a -> '0' |])
} |> Seq.iter (fun x  -> stdout.WriteLine x)

stdout.Flush()
