// https://atcoder.jp/contests/abc113/submissions/8531661
open System.IO
open System

let [| n; m;|] = stdin.ReadLine().Split()|>Array.map int
let preYearPairs = [| for _ in 1..m -> stdin.ReadLine().Split() |> Array.map int |]

let sw = new StreamWriter(Console.OpenStandardOutput())
sw.AutoFlush <- false
Console.SetOut(sw)

preYearPairs
|> Seq.mapi (fun i [| pre; year|] -> (year, i+1 , pre))
|> Seq.groupBy (fun (year,city,pre) -> pre)
|> Seq.map (fun (pre, elem) -> elem |> Seq.sort |> Seq.mapi (fun i (_,city,pre) -> (city,i+1,pre) ))
|> Seq.collect(fun x -> x)
|> Seq.sort
|> Seq.map (fun (_,num,pre) -> pre.ToString("000000") + num.ToString("000000"))
|> Seq.iter(stdout.WriteLine)

stdout.Flush()
