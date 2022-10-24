// https://atcoder.jp/contests/sumitrust2019/submissions/12257836
open System

let rec isSubList xs ys =
    match xs, ys with
    | [], _ -> true
    | _, [] -> false
    | x::xs, y::ys when x = y -> isSubList xs ys
    | xs, y::ys -> isSubList xs ys

let n = stdin.ReadLine() |> int
let s = stdin.ReadLine() |> Seq.toList

let a = List.sum [
    for i in ['0'..'9'] do
    for j in ['0'..'9'] do
    for k in ['0'..'9'] ->
    if isSubList [i; j; k] s then 1 else 0 ]

printfn "%d" a
