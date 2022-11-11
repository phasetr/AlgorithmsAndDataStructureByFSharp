// https://atcoder.jp/contests/abc134/submissions/7972341
open System.IO
open System

let n = stdin.ReadLine() |> int
let aArray =[|
    yield 0
    yield! (stdin.ReadLine().Split() |> Array.map int)|]

let bArray = Array.zeroCreate<int> (n+1)

let multipulesWithoutOwn m =
    seq{for i in m*2..m.. n -> i} |> Seq.map (fun i ->bArray.[i]) |> List.ofSeq

let f i =
    let result =
        aArray.[i] ^^^
            match multipulesWithoutOwn i with
            | [] ->  0
            | [x] -> x
            | x -> x |> List.reduce (fun total y -> total ^^^ y)
    bArray.[i] <- result

do [n.. -1 ..1] |> List.iter f

let ans =
    bArray |> Array.mapi (fun i x -> (i,x)) |> Array.filter (fun (i,x) -> x = 1)

//出力
let sw = new StreamWriter(Console.OpenStandardOutput())
sw.AutoFlush <- false
Console.SetOut(sw)

ans.Length |> stdout.WriteLine
ans |> Array.iter (fun (i,_) -> stdout.WriteLine(string i + " "))

stdout.Flush()
