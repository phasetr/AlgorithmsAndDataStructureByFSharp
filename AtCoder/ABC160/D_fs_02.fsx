// https://atcoder.jp/contests/abc160/submissions/11439889
open System

let readInts () = stdin.ReadLine().Split(' ') |> Array.map int64

let args = readInts() |> Array.map int
let n, x, y = args.[0], args.[1]-1, args.[2]-1

let res = Array.create n 0
for i in 0..n-1 do
    for j in i+1..n-1 do
        let k = min (abs (j-i)) (min (abs (j-x) + abs (i-y) + 1) (abs (j-y) + abs(i-x) + 1))
        res.[k] <- res.[k] + 1
for k in 1..n-1 do
    printfn "%d" res.[k]
