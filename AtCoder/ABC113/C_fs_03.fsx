// https://atcoder.jp/contests/abc113/submissions/24041869
open System
open System.IO
open System.Collections
open System.Collections.Generic
open System.Text

// --AutoFlufh-- //
let sw =
    new StreamWriter(Console.OpenStandardOutput())
    |> fun x -> x.AutoFlush <- false; x
Console.SetOut(sw)

let [|N;M|] = stdin.ReadLine().Split() |> Array.map int
let PY =
    [|for i in 1..M ->
        stdin.ReadLine().Split()
        |> Array.map int
        |> fun x ->
            [|x.[0]-1;x.[1];i-1|]
    |]
let mutable (Ken : int [] list []) = [|for i in 0..N-1 -> []|]

for i in PY do
    Ken.[i.[0]] <- i :: Ken.[i.[0]]

Ken <-
    Ken
    |> Array.map (fun x -> List.sortBy (fun z -> z.[1]) x )

let mutable ans = [|for i in 1..M -> (0,0)|]

for arr in Ken do
    arr
    |>  List.mapi (fun i x ->
                    ans.[x.[2]] <- (x.[0]+1,i+1))

for i in ans do
    printfn "%06d%06d" (fst i) (snd i)

sw.Flush()
