@"https://atcoder.jp/contests/abc063/submissions/24224359"
#r "nuget: FsUnit"
open System
open System.IO
open FsUnit

let rec solve = function
    | [] -> "yes"
    | x::xs ->
        if List.contains x xs then "no"
        else solve xs

stdin.ReadLine()
|> Seq.toList
|> solve |> printfn "%s"

List.ofSeq "uncopyrightable" |> solve |> should equal "yes"
List.ofSeq "different" |> solve |> should equal "no"
List.ofSeq "no" |> solve |> should equal "yes"
