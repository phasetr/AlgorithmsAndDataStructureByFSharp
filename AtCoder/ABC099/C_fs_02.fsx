// https://atcoder.jp/contests/abc099/submissions/2661522
open System
let n : int = int(Console.ReadLine())
let mutable res = n
let mutable i = 0
while i <= n do
    let mutable cc = 0
    let mutable t = i
    while t > 0 do
        cc <- cc + t % 6
        t <- t / 6
    t <- n - i
    while t > 0 do
        cc <- cc + t % 9
        t <- t / 9
    if res > cc then
        res <- cc
    i <- i + 1
printfn "%d" res
