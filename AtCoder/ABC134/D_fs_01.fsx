// https://atcoder.jp/contests/abc134/submissions/24750126
open System
open System.IO
open System.Collections
open System.Collections.Generic
open System.Text
let sw =
    new StreamWriter(Console.OpenStandardOutput())
    |> fun x -> x.AutoFlush <- false; x
Console.SetOut(sw)

let N = stdin.ReadLine() |> int
let A = stdin.ReadLine().Split() |> Array.map int

let mutable ans = [|for i in 1..N -> false|]

for i in 0..N-1 do
    let index = N - i - 1
    let mutable count = 0
    let maxi = N / (index+1)
    for j in 1..maxi do
        if ans.[(index+1) * j - 1] then
            count <- count + 1
    if count % 2 <> A.[index]
    then
        ans.[index] <- true



let a =
    ans
    |> Array.mapi (fun i x -> if x then i+1 else -1)
    |> Array.filter (fun x -> x <> -1)

let c = a.Length

printfn "%d" c
if c <> 0 then
    for i in 0..a.Length - 2 do
        printf "%d " (a.[i])
    printfn "%d " (Array.last a)

sw.Flush()
